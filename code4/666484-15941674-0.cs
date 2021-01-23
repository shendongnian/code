    public class FilePathWithDeleteResult : FilePathResult
    {
        public FilePathResult(string fileName, string contentType)
            : base(string fileName, string contentType)
        {
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            base.WriteFile(response);
            File.Delete(FileName);
            Directory.Delete(FileName);
        }
    }
