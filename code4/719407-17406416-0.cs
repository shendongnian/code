    string consPath = "C:\\WEB\\DirectiveFiles\\";
    private string FindExtension(string FileFullName)
    {
        
        int lastDOT = FileFullName.LastIndexOf(".");
        int fileNamelength = FileFullName.Length; 
        string myFileExtension = FileFullName.Substring(lastDOT + 1, fileNamelength - 1 - lastDOT);
        myFileExtension = myFileExtension.ToLower();
        if (myFileExtension == "jpg" || myFileExtension == "pdf" || myFileExtension == "gif" || myFileExtension == "zip")
        { }
        else
        {
            myFileExtension = "Error";
        }
        return myFileExtension;
    }
    if (fileUp1.HasFile)
                {
                    fileExtension = FindExtension(fileUp1.FileName);
                    if (fileExtension == "Error")
                    {
                        extFlag = true;
                        lblUpError1.Visible = true;
                        lblUpError1.Text = "Not Proper File " + fileUp1.FileName;
                        goto continueWithoutUpload;
                    }
                    else
                    {
                        filePath1 = consPath + DocID + "." + fileExtension;
                        fileUp1.SaveAs(consPath +
                            fileUp1.FileName);
                        File.Move(@consPath + fileUp1.FileName, @filePath1);
                        
                    }
                }
