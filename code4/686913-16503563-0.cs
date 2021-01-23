    [WebMethod]
    public static string uploadImage(string base64FileString){
        
       //Get all of the text right of the comma
        string base64PartTemp= base64FileString.Split(',')[1];
        //The final part of the base64 had a \" to remove
        //Now base64PartFinal is the base64 part of the image only
        string base64PartFinal= base64PartTemp.Split('\"')[0];
        //Get all of the text to the right of the period from original string
        string fileTypePart = base64FileString.Split('.')[1];
       
        //Because the file is an image the file type will be 3 chars
        string fileType = fileTypePart.Substring(0, 3);
        //Use a new guid for the file name, and append the fileType
        string finalFileName = Guid.NewGuid() + "." + fileType;
        //Turn the final base64 part into byte array
        byte[] imageBytes = Convert.FromBase64String(base64PartFinal);
        //Get the working directory of the project to store the files
        string path= System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //Append that I want to put the image in the images folder, under a designated filename
        path += "Images/" + finalFileName;
        //Write the image to file
        File.WriteAllBytes(path, imageBytes);
    
    ...
    }
