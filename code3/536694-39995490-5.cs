    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace EmptyDemo.compression
    {
    #region[Directive]
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    #endregion[Directive]
    /// <summary>
    /// This class is used to compress the image to
    /// provided size
    /// </summary>
    public class ImageCompress
    {
        #region[PrivateData]
        private static volatile ImageCompress imageCompress;
        private Bitmap bitmap;
        private int width;
        private int height;
        private Image img;
        #endregion[Privatedata]
        #region[Constructor]
        /// <summary>
        /// It is used to restrict to create the instance of the      ImageCompress
        /// </summary>
        private ImageCompress()
        {
        }
        #endregion[Constructor]
        #region[Poperties]
        /// <summary>
        /// Gets ImageCompress object
        /// </summary>
        public static ImageCompress GetImageCompressObject
        {
            get
            {
                if (imageCompress == null)
                {
                    imageCompress = new ImageCompress();
                }
                return imageCompress;
            }
        }
        /// <summary>
        /// Gets or sets Width
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        /// <summary>
        /// Gets or sets Width
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        /// <summary>
        /// Gets or sets Image
        /// </summary>
        public Bitmap GetImage
        {
            get { return bitmap; }
            set { bitmap = value; }
        }
        #endregion[Poperties]
        #region[PublicFunction]
        /// <summary>
        /// This function is used to save the image
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        public void Save(string fileName, string path)
        {
            if (ISValidFileType(fileName))
            {
                string pathaname = path + @"\" + fileName;
                save(pathaname, 60);
            }
        }
        #endregion[PublicFunction]
        #region[PrivateData]
        /// <summary>
        /// This function is use to compress the image to
        /// predefine size
        /// </summary>
        /// <returns>return bitmap in compress size</returns>
        private Image CompressImage()
        {
            if (GetImage != null)
            {
                Width = (Width == 0) ? GetImage.Width : Width;
                Height = (Height == 0) ? GetImage.Height : Height;
                Bitmap newBitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
                newBitmap = bitmap;
                newBitmap.SetResolution(80, 80);
                return newBitmap.GetThumbnailImage(Width, Height, null, IntPtr.Zero);
            }
            else
            {
                throw new Exception("Please provide bitmap");
            }
        }
        /// <summary>
        /// This function is used to check the file Type
        /// </summary>
        /// <param name="fileName">String data type:contain the file name</param>
        /// <returns>true or false on the file extention</returns>
        private bool ISValidFileType(string fileName)
        {
            bool isValidExt = false;
            string fileExt = Path.GetExtension(fileName);
            switch (fileExt.ToLower())
            {
                case CommonConstant.JPEG:
                case CommonConstant.BTM:
                case CommonConstant.JPG:
                case CommonConstant.PNG:
                    isValidExt = true;
                    break;
            }
            return isValidExt;
        }
        /// <summary>
        /// This function is used to get the imageCode info
        /// on the basis of mimeType
        /// </summary>
        /// <param name="mimeType">string data type</param>
        /// <returns>ImageCodecInfo data type</returns>
        private ImageCodecInfo GetImageCoeInfo(string mimeType)
        {
            ImageCodecInfo[] codes = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].MimeType == mimeType)
                {
                    return codes[i];
                }
            }
            return null;
        }
        /// <summary>
        /// this function is used to save the image into a
        /// given path
        /// </summary>
        /// <param name="path">string data type</param>
        /// <param name="quality">int data type</param>
        private void save(string path, int quality)
        {
            img = CompressImage();
            ////Setting the quality of the picture
            EncoderParameter qualityParam =
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ////Seting the format to save
            ImageCodecInfo imageCodec = GetImageCoeInfo("image/jpeg");
            ////Used to contain the poarameters of the quality
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = qualityParam;
            ////Used to save the image to a  given path
            img.Save(path, imageCodec, parameters);
        }
        #endregion[PrivateData]
    }
    }
