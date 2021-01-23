    public class UploadedFileObject
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public string Col6 { get; set; }
    }
    [HttpPost] public ActionResult Upload(HttpPostedFileBase File)
    {
    HttpPostedFileBase csvFile = Request.Files["adGroupCSV"];
    byte[] buffer = new byte[csvFile.ContentLength];
    csvFile.InputStream.Read(buffer, 0, csvFile.ContentLength);
    string csvString = System.Text.Encoding.UTF8.GetString(buffer);
    string[] lines = Regex.Split(csvString, "\r");
    List<UploadedFileObject> returnObject = new List<UploadedFileObject>();
    foreach (string line in lines)
    {
        String[] lineParts = line.Split(',');
        UploadedFileObject lineObject = new UploadedFileObject();
        lineObject.Col1 = lineParts[0];
        lineObject.Col2 = lineParts[1];
        lineObject.Col3 = lineParts[2];
        lineObject.Col4 = lineParts[3];
        lineObject.Col5 = lineParts[4];
        lineObject.Col6 = lineParts[5];
        returnObject.add(lineObject);
    }
    string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(returnObject);
        ViewData["CSV"] = json;
        return View(ViewData);
    }
