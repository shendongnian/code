        class EditableBitmap : IDisposable {
            public EditableBitmap(string filepath) {
                using (var bmp = new Bitmap(filepath)) this.bitmap = new Bitmap(bmp);
                this.path = System.IO.Path.GetFullPath(filepath);
                this.format = bitmap.RawFormat;
            }
            public Bitmap Bitmap { get { return bitmap; } }
            public void Save() {
                bitmap.Save(path, format);
                this.Dispose();   // Optional
            }
            public void Dispose() {
                if (bitmap != null) {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
            private Bitmap bitmap;
            private System.Drawing.Imaging.ImageFormat format;
            private string path;
        }
