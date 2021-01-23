    public string DownLoadfiletolocal(string FileURL, string Title)
    {
    
    //Copy.Copy is a webservice object that I consumed.
    
    Copy.Copy CopyObj = new Copy.Copy();
    CopyObj.Url = SiteURL + "/_vti_bin/copy.asmx"; // Dynamically passing SiteURL
    NetworkCredential nc2 = new NetworkCredential();
    nc2.Domain = string.Empty;
    nc2.UserName = _UserName;
    nc2.Password = _Password;
    
    
    string copySource = FileURL; //Pass full url for document.
    
    Copy.FieldInformation myFieldInfo = new Copy.FieldInformation();
    Copy.FieldInformation[] myFieldInfoArray = { myFieldInfo };
    byte[] myByteArray;
    
    // Call the web service
    uint myGetUint = CopyObj.GetItem(copySource, out myFieldInfoArray, out myByteArray);
    
    // Convert into Base64 String
    string base64String;
    base64String = Convert.ToBase64String(myByteArray, 0, myByteArray.Length);
    
    // Convert to binary array
    byte[] binaryData = Convert.FromBase64String(base64String);
    
    // Create a temporary file to write the text of the form to
    string tempFileName = Path.GetTempPath() + "\\" + Title;
    
    // Write the file to temp folder
    FileStream fs = new FileStream(tempFileName, FileMode.Create, FileAccess.ReadWrite);
    fs.Write(binaryData, 0, binaryData.Length);
    fs.Close();
    
    return tempFileName;
    
    }
