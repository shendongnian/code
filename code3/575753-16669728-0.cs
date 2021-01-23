    #region Using directives
    using System;
    using System.Drawing;
    using System.Collections;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using OpenNETCF.Drawing.Imaging;
    using System.IO;
    #endregion
    ....
    const string szFileName = @"\Storage Card\TEMP\2MBJPEG.JPG";
    private void Form1_Load(object sender, EventArgs e)
    {
    IBitmapImage imageBitmap;
    FileStream fsImage;
    fsImage = new FileStream(
        szFileName,
        FileMode.Open);
    imageBitmap = CreateThumbnail(
        fsImage,
        new Size(100, 100));
    Bitmap bm = ImageUtils.IBitmapImageToBitmap(
        imageBitmap);
    pictureBox1.Image = bm;
    }
    static public IBitmapImage CreateThumbnail(Stream stream, Size size)
    {
    IBitmapImage imageBitmap;
    ImageInfo ii;
    IImage image;
    ImagingFactory factory = new ImagingFactoryClass();
        factory.CreateImageFromStream(
        new StreamOnFile(stream), 
        out image);
    image.GetImageInfo(out ii);
    factory.CreateBitmapFromImage(
        image, 
        (uint)size.Width, 
        (uint)size.Height,
        ii.PixelFormat, 
        InterpolationHint.InterpolationHintDefault, 
        out imageBitmap);
        return imageBitmap;
    }
