    try
            {
                string strURL=txtFileName.Text;
                WebClient req=new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer= true;
                response.AddHeader("Content-Disposition","attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data=req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch(Exception ex)
            {
         }
