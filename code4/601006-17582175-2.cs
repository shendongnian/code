    public static class BitmapExtension
    {
        public static void SetPath(this Bitmap bitmap, string path)
        {
            bitmap.Tag = path;
        }
        public static string GetPath(this Bitmap bitmap)
        {
            return bitmap.Tag as string;
        }
    }
