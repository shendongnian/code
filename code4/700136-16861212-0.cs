    string filePath = String.Format({0}{1}", System.IO.Path.GetTempPath(), FileUpload1.FileName); // Save to temp directory
    FileUpload1.SaveAs(filePath);
    using (TextFieldParser parser = new TextFieldParser(filePath))
    {
      //...
    }
    File.Delete(filePath); // Delete the file if you're done with it
