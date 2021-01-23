    public void DetectBigBlobs(Bitmap bitmap)
        {
            BlobCounter blobCounter = new BlobCounter();
            
            Graphics g = Graphics.FromImage(bitmap);
            //filtering the blobs before searching for blobs 
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = bitmap.Height/3;
            blobCounter.MinWidth = bitmap.Width/3;
            blobCounter.ProcessImage(bitmap);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            foreach (Blob b in blobs)
            { 
                //getting the found blob edgepoints 
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(b);
                //if you want to mark every edge point RED 
                foreach (IntPoint point in edgePoints)
                    bitmap.SetPixel(point.X, point.Y, Color.Red);
                //if you want to draw a rectangle around the blob 
                g.DrawRectangle(Pens.Blue,b.Rectangle);
                
            }
            
            g.Dispose();
        }
