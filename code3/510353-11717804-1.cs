                        string data = "MONEY-ID123456:MONEY-STAT43:MONEY-PAYetr-1232832938";
                        data = data.Replace("MONEY-", ";");
                        string[] myArray = data.Split(';');
                        foreach (string s in myArray)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                if (s.StartsWith("ID"))
                                { 
                                
                                }
                                else if (s.StartsWith("STAT"))
                                {
                                
                                }
                                else if (s.StartsWith("PAYetr"))
                                { 
                                
                                }
                            }
                        }
