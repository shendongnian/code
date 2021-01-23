    public class DataImportHelper : IDisposable
    {
        private readonly string _fileName;
        private readonly string _tempFilePath;
        public DataImportHelper(HttpPostedFileBase file, string tempFilePath)
        {
            _fileName = file.FileName;
            _tempFilePath = Path.Combine(tempFilePath, _fileName);
            (new FileInfo(_tempFilePath)).Directory.Create();
            file.SaveAs(_tempFilePath);
        }
        public IQueryable<T> All<T>(string sheetName = "")
        {
            if (string.IsNullOrEmpty(sheetName))
            {
                sheetName = (typeof (T)).Name;
            }
            var excelSheet = new ExcelQueryFactory(_tempFilePath);
            return from t in excelSheet.Worksheet<T>(sheetName)
                   select t;
        }
        public void Dispose()
        {
            File.Delete(_tempFilePath);
        }
    }
