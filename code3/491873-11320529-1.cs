    namespace ImageResizer.Plugins.TiffDecoder
    {
      using System;
      using System.Collections.Generic;
      using System.Drawing;
      using System.Drawing.Imaging;
      using System.Globalization;
      using System.IO;
      using System.Linq;
      using BitMiracle.LibTiff.Classic;
      using ImageResizer;
      using ImageResizer.Configuration;
      using ImageResizer.Resizing;
      public class TiffDecoder : BuilderExtension, IPlugin, IFileExtensionPlugin
      {
        private static readonly string[] supportedExtensions = new[] { ".tiff", ".tif", ".tff" };
        public IPlugin Install(Config c)
        {
          c.Plugins.add_plugin(this);
          return this;
        }
        public bool Uninstall(Config c)
        {
          c.Plugins.remove_plugin(this);
          return true;
        }
        public IEnumerable<string> GetSupportedFileExtensions()
        {
          return supportedExtensions;
        }
        public override Bitmap DecodeStream(Stream s, ResizeSettings settings, string optionalPath)
        {
          var requested = "tiffdecoder".Equals(settings["decoder"], StringComparison.OrdinalIgnoreCase);
          if (!string.IsNullOrEmpty(settings["decoder"]) && !requested)
          {
            return null; // Don't take it away from the requested decoder
          }
          // If a tiff is coming in, try first, before Bitmap tries to parse it.      
          if (requested || (optionalPath != null && supportedExtensions.Any(ext => optionalPath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))))
          {
            return this.Decode(s, settings);
          }
          return null;
        }
        public override Bitmap DecodeStreamFailed(Stream s, ResizeSettings settings, string optionalPath)
        {
          // Catch tiff files not ending in an expected extension
          try
          {
            return this.Decode(s, settings);
          }
          catch
          {
            return null;
          }
        }
        public Bitmap Decode(Stream s, ResizeSettings settings)
        {
          return DecodeTiffTo32BitBitmap(s, settings["page"]);
        }
        private static Bitmap DecodeTiffTo32BitBitmap(Stream s, string page)
        {
          s.Position = 0;
          using (var image = Tiff.ClientOpen(string.Empty, "r", s, new TiffStream()))
          {
            SetDirectory(image, page);
            // Find the width and height of the image
            var value = image.GetField(TiffTag.IMAGEWIDTH);
            var width = value[0].ToInt();
            value = image.GetField(TiffTag.IMAGELENGTH);
            var height = value[0].ToInt();
            // Read the image into the memory buffer
            var raster = new int[height * width];
            if (!image.ReadRGBAImage(width, height, raster))
            {
              return null;
            }
            // Caller needs to handle disposing the bitmap.
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            var bits = new byte[bmpdata.Stride * bmpdata.Height];
            for (var y = 0; y < bmp.Height; y++)
            {
              var rasterOffset = y * bmp.Width;
              var bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;
              for (var x = 0; x < bmp.Width; x++)
              {
                var rgba = raster[rasterOffset++];
                bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                bits[bitsOffset++] = (byte)(rgba & 0xff);
                bits[bitsOffset++] = (byte)((rgba >> 24) & 0xff);
              }
            }
            System.Runtime.InteropServices.Marshal.Copy(bits, 0, bmpdata.Scan0, bits.Length);
            bmp.UnlockBits(bmpdata);
            return bmp;
          }
        }
        /// <summary>
        /// Sets the TIFF directory to the first that matches the requested page number, otherwise:
        /// - If page not set OR less than 0, use the first page in the TIFF.
        /// - If tiff has no directories with the "PAGE" tag, use the first frame in the TIFF.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="page">The page.</param>
        /// <remarks>
        /// From what I can tell a TIFF image can store any pages in any directory, so the 1st dir 
        /// might not hold the 1st page - this is why we first iterate all frames looking for a PAGE tag.
        /// </remarks>    
        private static void SetDirectory(Tiff image, string page)
        {
          var pageIndex = GetAdjustedPage(page);
          var numberOfDirectories = image.NumberOfDirectories();
          for (short dirNumber = 0; dirNumber < numberOfDirectories; ++dirNumber)
          {
            image.SetDirectory(dirNumber);
            // Ignore pages that might be thumbnails
            var subFileType = image.GetField(TiffTag.SUBFILETYPE);
            if (subFileType == null || subFileType[0].ToString().ToUpper() != "PAGE")
            {
              continue;
            }
            // Stop if page found
            if (pageIndex == int.Parse(image.GetField(TiffTag.PAGENUMBER)[0].ToString()))
            {
              return;
            }
          }
          // Default to the first frame if the page wasn't found.
          image.SetDirectory(0);
        }
        private static int GetAdjustedPage(string page)
        {
          var pageIndex = 1;
          if (!string.IsNullOrEmpty(page))
          {
            int.TryParse(page, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out pageIndex);
          }
          // So users can use 1-based numbers
          return Math.Max(1, pageIndex) - 1;
        }
      }
    }
