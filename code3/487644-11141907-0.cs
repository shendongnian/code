            DS.SizeLimit = 10; //set small for testing, change before production ;)            
            DS.Filter = "(sAMAccountName=*)";            
            var list = new List<SearchResult>();
            SearchResultCollection res;
            while ((res = DS.FindAll()).Count > 0)
            {
                list.AddRange(res.Cast<SearchResult>());       
                var last = list[list.Count - 1].GetDirectoryEntry().InvokeGet("sAMAccountName").ToString()
                    + "0"; // <- small cheat to prevent doubles because the search does not support > , but does support >=
                DS.Filter = "(sAMAccountName>=" + last + ")";
            }
