                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "text/plain";
                    Response.AppendHeader("Content-Disposition", "attachment; filename = " + fileName);
                    Response.TransmitFile(Server.MapPath("~/foldername/" + fileName));
                    Response.End();
