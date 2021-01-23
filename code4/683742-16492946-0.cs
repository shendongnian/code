                using (StreamReader r = new StreamReader(@"C:\Users\****\Desktop\strings.txt"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines++;
                        if (lines >= 6)
                        {
                            string[] bits = line.Split(':');
                            if(string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }
                            try
                            {
                                strlist.Add(bits[0].Substring(10), bits[1]);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                }
                foreach(var Title in Titles)
                {
                    string searchstr = Title.Parent.Name.ToString();
                    string val = Title.Value;
                    string has = @"Gameplay/Excel/Books/" + searchstr + ":" + val;
                    ulong hash = FNV64.GetHash(has);
                    var hash2 = " " + string.Format("0x{0:X}", hash);
                    try
                    {
                        if (strlist.ContainsKey(hash2))
                        {
                            list.Add(strlist[hash2]);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                }
