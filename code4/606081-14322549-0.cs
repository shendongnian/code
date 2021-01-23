    DirectoryInfo[] subdirs = dInfo.GetDirectories().OrderBy(d =>
                        {
                            int i = 0;
                            if (d.Name.Contains("Lightning ") && d.Name.Contains(" Length") && d.Name.IndexOf("Lightning ") < d.Name.IndexOf(" Length"))
                            {
                                string z = d.Name.Substring(("Lightning ").Length);
                                string f = z.Substring(0, z.IndexOf(" Length"));
                                if (Int32.TryParse(f, out i))
                                    return i;
                                else
                                    return -1;
                            }
                            else
                                return -1;
                        }).ToArray();
