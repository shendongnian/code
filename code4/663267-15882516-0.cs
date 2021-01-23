    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(digitalAsset.FullFilePath);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" +     digitalAsset.FileName);
                    Stream inputStream = response.GetResponseStream();
                    byte[] buffer = new byte[512];
                    int read;
                    while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Response.OutputStream.Write(buffer, 0, read);
                        Response.Flush();
                    }
                    Response.End();
                }
