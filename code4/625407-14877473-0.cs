    using System;
    using System.Collections.Generic;
    using System.IO;
    using FreeImageAPI;
    namespace Tiff
    {
        static class TiffConverter
        {
            /// <summary>
            /// <para>Wraps a list of JPEG images into a simple multi-page TIFF container.</para>
            /// <para>(Might not work with all JPEG formats.)</para>
            /// </summary>
            /// <param name="jpegs">The JPEG-image to convert</param>
            /// <returns></returns>
            public static byte[] WrapJpegs(List<byte[]> jpegs)
            {
                if (jpegs == null || jpegs.Count == 0 || jpegs.FindIndex(b => b.Length == 0) > -1)
                    throw new ArgumentNullException("Image data must not be null or empty");
                MemoryStream tiffData = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(tiffData);
                uint offset = 8; // size of header, offset to IFD
                ushort entryCount = 14; // entries per IFD
                #region IFH - Image file header
                // magic number
                if (BitConverter.IsLittleEndian)
                    writer.Write(0x002A4949);
                else
                    writer.Write(0x4D4D002A);
                
                // offset to (first) IFD
                writer.Write(offset);
                #endregion IFH
                #region IFD Image file directory
                // write image file directories for each jpeg
                for (int i = 0; offset > 0; i++)
                {
                    // get data from jpeg with FreeImage
                    FreeImageBitmap jpegImage;
                    try
                    {
                        jpegImage = new FreeImageBitmap(new MemoryStream(jpegs[i]));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Could not load image data at index " + i, ex);
                    }
                    if (jpegImage.ImageFormat != FREE_IMAGE_FORMAT.FIF_JPEG)
                        throw new ArgumentException("Image data at index " + i + " is not in JPEG format");
                    // dta to write in tags
                    uint width = (uint)jpegImage.Width;
                    uint length = (uint)jpegImage.Height;
                    uint xres = (uint)jpegImage.HorizontalResolution;
                    uint yres = (uint)jpegImage.VerticalResolution;
                    // count of entries:
                    writer.Write(entryCount);
                    offset += 6 + 12 * (uint)entryCount; // add lengths of entries, entry-count and next-ifd-offset
                    // TIFF-fields / IFD-entrys:
                    // {TAG, TYPE (3 = short, 4 = long, 5 = rational), COUNT, VALUE/OFFSET}
                    uint[,] fields = new uint[,] { 
                        {254, 4, 1, 0}, // NewSubfileType
                        {256, 4, 1, width}, // ImageWidth
                        {257, 4, 1, length}, // ImageLength
                        {258, 3, 3, offset}, // BitsPerSample
                        {259, 3, 1, 7}, // Compression (new JPEG)
                        {262, 3, 1, 6}, //PhotometricInterpretation (YCbCr)
                        {273, 4, 1, offset + 22}, // StripOffsets (offset IFH + entries + values of BitsPerSample & YResolution & XResolution)
                        {277, 3, 1, 3}, // SamplesPerPixel
                        {278, 4, 1, length}, // RowsPerStrip
                        {279, 4, 1, (uint)jpegs[i].LongLength}, // StripByteCounts
                        {282, 5, 1, offset + 6}, // XResolution (offset IFH + entries + values of BitsPerSample)
                        {283, 5, 1, offset + 14}, // YResolution (offset IFH + entries + values of BitsPerSample & YResolution)
                        {284, 3, 1, 1}, // PlanarConfiguration (chunky)
                        {296, 3, 1, 2} // ResolutionUnit
                    };
                    // write fields
                    for (int f = 0; f < fields.GetLength(0); f++)
                    {
                        writer.Write((ushort)fields[f, 0]);
                        writer.Write((ushort)fields[f, 1]);
                        writer.Write(fields[f, 2]);
                        writer.Write(fields[f, 3]);
                    }
                    // offset of next IFD
                    if (i == jpegs.Count - 1)
                        offset = 0;
                    else
                        offset += 22 + (uint)jpegs[i].LongLength; // add values (of fields) length and jpeg length
                    writer.Write(offset);
                    #region values of fields
                    // BitsPerSample
                    writer.Write((ushort)8);
                    writer.Write((ushort)8);
                    writer.Write((ushort)8);
                    // XResolution
                    writer.Write(xres);
                    writer.Write(1);
                    // YResolution
                    writer.Write(yres);
                    writer.Write(1);
                    #endregion values of fields
                    // actual image data
                    writer.Write(jpegs[i]);
                }
                #endregion IFD
                writer.Close();
                return tiffData.ToArray();
            }
        }
    }
