     dynamic friends = fb.Get("/me/friends?limit=5000&offset=0");
                Dictionary<string, string> resultList = new Dictionary<string, string>();
                foreach (var item in friends.data)
                {
                    var newdata=item;
                    string item1 = newdata[0].ToString();
                    string item2 = newdata[1].ToString();
                    if (resultList.ContainsKey(item1))
                    {
                        item1 = item1 + "duplicate";  
                    }
                    resultList.Add(item1,item2);
                }
