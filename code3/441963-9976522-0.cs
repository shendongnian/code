        //open the data file
    mrgDoc.MailMerge.OpenHeaderSource(pathToHdr);
    mrgDoc.MailMerge.OpenDataSource(pathToDB);
    mrgDoc.MailMerge.SuppressBlankLines = true;
    mrgDoc.MailMerge.ViewMailMergeFieldCodes = 0;
                        
    mrgDoc.Application.ActiveDocument.Range(0, 0).Select();                
    try
    {
        if (!string.IsNullOrWhiteSpace(pathToDestinationFile) && Directory.Exists(Path.GetDirectoryName(pathToDestinationFile)))
        mrgDoc.SaveAs(pathToDestinationFile);
    }
    catch
    {
        wrdApp.Visible = true;
    }
