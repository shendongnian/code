    class ImageLoader : IDisposable {
        public string FileName { get; set; }
        public Image Image { get; set; }
        public Control Parent { get; set; }
        private FileStream currentFileStream;
        private byte[] buffer;
        private object locker = new object();
        Control parent;
        private volatile bool dispose = false;
        public ImageLoader(Control parent, string fileName) {
            Parent = parent;
            FileName = fileName;
            Image = null;
            currentFileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024 * 8, true);
            buffer = new byte[currentFileStream.Length];
            currentFileStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(FileReadComplete), null);
        }
        private void FileReadComplete(IAsyncResult ar) {
            lock (locker) {
                try { currentFileStream.EndRead(ar); } catch (ObjectDisposedException) { }
                if (!dispose) {
                    using (MemoryStream ms = new MemoryStream(buffer))
                        Image = new Bitmap(ms);
                    Parent.Invalidate();
                }
                try { currentFileStream.Close(); } catch(IOException) { }
            }
        }
        public void Dispose() {
            lock (locker) {
                if (dispose)
                    return;
                dispose = true;
                try { currentFileStream.Close(); } catch(IOException) { }
                if (Image != null)
                    Image.Dispose();
            }
        }
    }
