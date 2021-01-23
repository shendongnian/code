    private void button1_Click(object sender, EventArgs e)
    {
      //This is the PDF file we want to update.
      string filename = @"c:\temp\MyFile.pdf";
      //Create the OleDocumentProperties object.
      DSOFile.OleDocumentProperties dso = new DSOFile.OleDocumentProperties();
      //Open the file for writing if we can. If not we will get an exception.
      dso.Open(filename, false,
    
        DSOFile.dsoFileOpenOptions.dsoOptionOpenReadOnlyIfNoWriteAccess);
      //Set the summary properties that you want.
      dso.SummaryProperties.Title = "This is the Title";
      dso.SummaryProperties.Subject = "This is the Subject";
      dso.SummaryProperties.Company = "RTDev";
      dso.SummaryProperties.Author = "Ron T.";
      //Save the Summary information.
      dso.Save();
      //Close the file.
      dso.Close(false);
    }
