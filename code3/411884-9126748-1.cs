    public void ProcessRequest (HttpContext context) {
    context.Response.ContentType = "application/zip";
    context.Response.AddHeader("Content-Disposition", "attachment; filename=catalog" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip");
        using (ZipFile zip = new ZipFile(Encoding.UTF8))
        {
            foreach (DataRow dr in dt.Rows)
            {
                string barCode = "C:/tmp/bc/" + dr["ProductCode"] + ".gif";
    
                if (File.Exists(barCode))
                {
                    if (!zip.EntryFileNames.Contains("bc" + dr["ProductCode"] + ".gif"))
                    {
                        try
                        {
                            // The file stream is opened here
                            using (StreamReader sr = new StreamReader(barCode))
                            {
                                if (sr.BaseStream.CanRead)
                                    zip.AddEntry("bc" + dr["ProductCode"] + ".gif", sr.BaseStream);
                            }
                            // The file stream is closed here
                        }
                        catch (Exception ex)
                        {
                            // never hits the catch
                            context.Response.Write(ex.Message);
                        }
                    }
                }
            }
            
            // The closed file streams are accessed here
            zip.Save(context.Response.OutputStream);
        }
    }
