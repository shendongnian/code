                    try
                    {
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("content-disposition", "attachment;filename=\"" + Path.GetFileName(path.FullName) + "\"");
                        Response.AddHeader("content-length", path.Length.ToString());
                        Response.TransmitFile(path.FullName);
                        Response.Flush();
                    }
                    finally
                    {
                        File.Delete(Server.MapPath("~/"+tpacode+".zip"));
                    }
