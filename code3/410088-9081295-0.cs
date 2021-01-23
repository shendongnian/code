            // Create the bitmap we'll render to
            RenderTargetBitmap bmp = new RenderTargetBitmap(100, 100, 96, 96, PixelFormats.Pbgra32);
            
            // Create a list of random circle geometries
            List<Geometry> geoList = new List<Geometry>();
            Random rand = new Random();
            for (int i=0; i<10; i++)
            {
                double radius = rand.Next(5, 10);
                Point center = new Point(rand.Next(25, 75), rand.Next(25,75));
                geoList.Add(new EllipseGeometry(center, radius, radius));
            }
            // The light-weight visual element that will draw the geometries
            DrawingVisual viz = new DrawingVisual();
            using (DrawingContext dc = viz.RenderOpen())
            { // get a device context so we can draw the geometries to the DrawingVisual
                foreach (var g in geoList)
                    dc.DrawGeometry(Brushes.Red, null, g);
            } // the DC is closed as it falls out of the using statement
            // draw the visual on the bitmap
            bmp.Render(viz);
            
            // create an encoder to save the file
            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            // add this bitmap to the set of frames it will save out
            pngEncoder.Frames.Add(BitmapFrame.Create(bmp));
            using (FileStream file = new FileStream("Spots.png", FileMode.Create))
                pngEncoder.Save(file);
