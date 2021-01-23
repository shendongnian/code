    public List<string> GetFileKeyValues(string fileName, string key)
            {
                List<string> res = new List<string>();
                try
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        using (System.IO.StreamReader tr = new System.IO.StreamReader(fileName))
                        {
                            bool keyFound = false;
                            while (!tr.EndOfStream)
                            {
                                string s = tr.ReadLine().ToLower();
                                if (s.Contains(key.ToLower())) keyFound = true;
                                else
                                {
                                    if (keyFound)
                                    {
                                        if (!s.Contains("{") && !s.Contains("}")) res.Add(s);
                                        if (s.Contains("}")) break;
                                    }
                                }
                            }
                            tr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return res;
            }
