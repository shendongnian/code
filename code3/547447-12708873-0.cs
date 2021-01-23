    public class ScannableFile : IScannable
    {
        private string fullFilename;
        public ScannableFile(string fullFilename)
        {
            this.fullFileName = fullFilename;
        }
        public byte[] GetContent()
        {
            return File.ReadAllBytes(this.fullFilename);
        }
    }
