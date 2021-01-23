    var datas = from query in loadedData.Descendants("news")
                                    select new News
                                    {
                                        Title = (string)query.Element("title"),
                                        Id = (string)query.Element("id"),
                                        StrDate = (string)query.Element("date"),
                                        list = (from xele in query.Descendants("machine")
                                               select xele.Value).ToList<string>();   
                                    };
