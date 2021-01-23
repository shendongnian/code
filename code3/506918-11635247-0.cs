    var listSrc = new List<string>
                               {
                                   "klaus",
                                   "male",
                                   "spain",
                                   "lissy",
                                   "england",
                                   "female",
                                   "peter",
                                   "usa",
                                   "male",
                               };
                var dlist = new List<Dictionary<string, string>>();
    
                for (var i = 0; i < listSrc.Count; i++)
                {
                    var captions = new List<string>
                                       {
                                           "Name",
                                           "Gender",
                                           "Country"
                                       };
    
                    var list = listSrc.Take(3).ToList();
                    listSrc.RemoveRange(0, 3);
    
                    dlist.Add(list.ToDictionary(x => captions[list.IndexOf(x)], x => x));
                }
