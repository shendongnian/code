    var filePath = Path.Combine(Server.MapPath("~/Document"), fileName);
                    file.SaveAs(filePath);
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        using (StreamReader sr = new StreamReader(Path.Combine(Server.MapPath("~/Document"), fileName)))
                        {
                            while (sr.Peek() >= 0)
                            {
                                strbuild.AppendFormat(sr.ReadLine());
                            }
                        }
                    }
