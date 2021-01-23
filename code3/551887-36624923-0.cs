    public void DownloadFile()
            {
                String FileName = "201604112318571964-sample2.txt";
                String FilePath = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Uploads/" + FileName;
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);
                response.Flush();
                response.End();
    
              
            }
