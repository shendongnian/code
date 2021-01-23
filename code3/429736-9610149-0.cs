    [HttpPost]
    public ActionResult ExportCSVFile(string uploadCsv) 
    {
      string toReturn = Server.UrlDecode(data);
      return File(System.Text.Encoding.UTF8.GetBytes(toReturn), "text/csv", "exportedData.csv");
    }
