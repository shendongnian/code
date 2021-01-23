    public void Upload()
            {
                WebRequest request = HttpWebRequest.Create("http://localhost:7267/Search/uploadFile");
                request.Method = "POST";
                //This is important, MVC uses the content-type to discover the action parameters
                request.ContentType = "application/x-www-form-urlencoded";
    
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\myFile.jpg");
    
                StringBuilder serializedBytes = new StringBuilder();
                
                //Let's serialize the bytes of your file
                fileBytes.ToList<byte>().ForEach(x => serializedBytes.AppendFormat("{0}.", Convert.ToUInt32(x)));
    
