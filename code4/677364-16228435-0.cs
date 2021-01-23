        using FreeImageAPI;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    // load image, this can by your 16-bit tif
                    FIBITMAP dib = FreeImage.LoadEx("myfile.tif");
                    // convert to 8-bits
                    dib = FreeImage.ConvertToGreyscale(dib);
                    // rotate image by 90 degrees
                    dib = FreeImage.Rotate(dib, 90);
                    // save image
                    FreeImage.SaveEx(dib, "newfile.png");
                    // unload bitmap
                    FreeImage.UnloadEx(ref dib);
               }
            }
    }
