        using System;
    using M = MagickNet;
    using System.Drawing;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                M.Magick.Init();
                M.Image img = new M.Image("file.jpg");
                img.Resize(new Size(100, 100));
                img.Write("newFile.png");
                MagickNet.Magick.Term();
            }
        }
    }
