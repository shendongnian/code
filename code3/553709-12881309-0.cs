    public static Bitmap LoadBitmapNolock(string path) {
        using (var img = Image.FromFile(path)) {
            return new Bitmap(img);
        }
    }
