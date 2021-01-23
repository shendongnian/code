     @{
                //some how find out what page we are on so we can set the active attribute
                var HomeClass = "non-active";
                var AboutClass = "non-active";
    
                string path = HttpContext.Current.Request.FilePath;
                if (path.Contains("Home"))
                {
                    HomeClass = "active";
                }
                if (path.Contains("About"))
                {
                    AboutClass = "active";
                }
              
   
        }
