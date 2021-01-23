    namespace Project1
    {
      class Class1
      {
    
        public void DownloadIt()
        {
            WebClient Client = new WebClient ();
            Client.DownloadFile("https://webgis.dme.qld.gov.au/webgis/webqmin/shapes/epm.tar",      @"d:\epm.tar");
        }
      }
    }
