     public class Service1 : IService1
        {
            public Stream GetImage()
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
                using(WebClient Client = new WebClient())
                {
                   using(StreamReader Reader = new StreamReader(Client.OpenRead("FILE URL")))
                   {
                     try
                     {
                       string Contents = Reader.ReadToEnd();
                       Reader.Close();
                       return Contents;
                     }
                     catch
                     {
                        return string.Empty;
                     }
                   }
                }
            }
        }
