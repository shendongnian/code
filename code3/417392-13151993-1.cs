        try
        {
          //Create a FTP Request Object and Specfiy a Complete Path
          //  System.Net.WebRequest.Create(strFTPFilePath);
          FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create(strFTPFilePath);       
            //Call A FileUpload Method of FTP Request Object
            reqObj.Method = WebRequestMethods.Ftp.UploadFile;
            //If you want to access Resourse Protected,give UserName and PWD
            reqObj.Credentials = new NetworkCredential(strUserName, strPassword);
            // Copy the contents of the file to the byte array.
            byte[] fileContents = File.ReadAllBytes(strLocalFilePath);
            reqObj.ContentLength = fileContents.Length;
      
            //Upload File to FTPServer
            Stream requestStream = reqObj.GetRequestStream();
          //  Stream requestStream = response.GetResponseStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)reqObj.GetResponse();
            response.Close();
            Label1.Text = "File Transfered Completed" + response.StatusDescription;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return true;
    }  `
  
