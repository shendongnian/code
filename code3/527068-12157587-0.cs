    List<string> first = new List<string>();
                first.Add("University");
                first.Add("Standard");
    
                List<List<string>> second = new List<List<string>>();
                second.Add(first);
    
                List<List<List<string>>> third = new List<List<List<string>>>();
                third.Add(second);
    
                var e = third.Find(delegate(List<List<string>> r) 
                            { 
                                bool isValid = false; 
                                if(r.Count > 0)
                                { 
                                    foreach(List<string> s in r)
                                    { 
                                        if(s.Count > 0 ) 
                                        { 
                                            isValid = s.FindAll(delegate(string t){ return t.StartsWith("uni", StringComparison.OrdinalIgnoreCase);}).Count > 0;
                                        }
                                    }
                                }
                                return isValid;
                            });
