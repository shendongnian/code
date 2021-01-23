                    string search_text = text;
                    string old;
                    string n="";
                    StreamReader sr = File.OpenText(FileName);
                    while ((old = sr.ReadLine()) != null)
                    {
                        if (!old.Contains(search_text))
                        {
                            n += old+Environment.NewLine;  
                        }
                    }
                    sr.Close();
                    File.WriteAllText(FileName, n);
