    byte[] byteArray = new byte[0];
                    using (Image img = Image.FromFile(url))
                    {
    
                        using (MemoryStream stream = new MemoryStream())
                        {
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            stream.Close();
                            byteArray = stream.ToArray();
                        }
    
                    }
    
                    String contentType = url.EndsWith("jpg") ? "image/jpg" : "image/png";
                    var responseHeader = WebServerUtils.Instance.CreateResponseHeader(byteArray.Length, contentType);
                    responseHeader.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);
                    response.OnResponse(responseHeader, new BufferedProducer(byteArray));
