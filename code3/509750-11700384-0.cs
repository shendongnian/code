                // load existing bmps 
            var bmp1 = new Bitmap("test2.bmp");
            var bmp2 = new Bitmap("test2.bmp");
            // apply transforms to bmp1 
            var canvas1 = Graphics.FromImage(bmp1);
            canvas1.ScaleTransform(0.5f, 0.5f);
            canvas1.RotateTransform(45.0f);
            canvas1.Save();
            canvas1.DrawImage(bmp1,100, 0);
            bmp1.Save("test1res.bmp");
            var bmpres1 = new Bitmap("test1res.bmp");
            // apply transforms to bmp2
            var resbmp2 = new Bitmap(1000, 1000);
            var canvas2 = Graphics.FromImage(bmp2);
            canvas2.ScaleTransform(0.5f, 0.5f);
            canvas2.RotateTransform(45.0f);
            canvas2.Save();
            canvas2.DrawImage(bmp2, 100, 0);
            bmp2.Save("test2res.bmp");
            var bmpres2 = new Bitmap("test2res.bmp");
            // create final merged bmp 
            var mergedBmp = new Bitmap(1000, 1000);
            mergedBmp.SetResolution(bmp1.HorizontalResolution, bmp1.VerticalResolution);
            // draw transformed images on to final bmp 
            var mergedCanvas = Graphics.FromImage(mergedBmp);
            mergedCanvas.DrawImage(bmpres1, 0, 0);
            mergedCanvas.DrawImage(bmpres2, 500, 0);
            mergedCanvas.Save();
            Graphics graph = mergedCanvas;
           // Bitmap bmpPicture = new Bitmap("test2.bmp");
            graph.DrawImage(mergedBmp, 0, 0);
            mergedBmp.Save("res.bmp");
