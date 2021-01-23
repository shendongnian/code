    WebClient webClient= new WebClient();
    Stream stream = webClient.OpenRead("http://servername:1056/ExcelFiles/Myfile.xlsx");
      //StreamReader streamReader = new StreamReader(stream);
      //String content = streamReader.ReadToEnd();
    // Read the Document using SpreadSheetDocument Method 
    var ssDoc = SpreadSheetDocument.Open(stream, false);
