        {
                //SuggestStrings will have the logic to return array of strings either from cache/db
                var CurrentuserId = CloudKaseWSClient.GetUserDetail(tokenUsr, tokenPasswd, Username);
                List<string> l = new List<string>();
                var SearchResults = ("Select Database Query").ToList();
                foreach (var i in SearchResults)
                {
                    l.Add(i.name);
                }
                string[] arr = l.ToArray();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(arr);
            txtSearchUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearchUser.AutoCompleteCustomSource = collection;
        }
