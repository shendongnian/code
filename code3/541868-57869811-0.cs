         string ImagePath = "";
     
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImagePath);
            string a = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); 
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream.CanRead)
                { a = "OK"; }
            }
           
            catch { }
