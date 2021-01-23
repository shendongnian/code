    var results = db.Blogs.AsEnumerable()
                        .Select(sr => new
                        {
                            Searchresult = sr,
                            Words = Regex.Split(sr.Name, @"[^\S\r\n {1,}").Union(Regex.Split(sr.Name2, @"[^\S\r\n]{1,}"))
                        })
                        .OrderByDescending(x => x.Words.Count(w => {
                            foreach (var item in searchTerms)
                            {
                                if(w.ToLower().Contains(item))
                                {
                                    return true;
                                }
                            }
                               return false;
                        }))
                        .Select(x => x.Searchresult);
