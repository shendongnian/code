     string subPath = HttpContext.Current.Server.MapPath(@"~/Images/RequisitionBarCode/");
                bool exists = System.IO.Directory.Exists(subPath);
                if(!exists)
                System.IO.Directory.CreateDirectory(subPath); 
    string path = HttpContext.Current.Server.MapPath(@"~/Images/RequisitionBarCode/" + OrderId + ".png");
