        public static void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion,ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))            
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);                
            }
        }
