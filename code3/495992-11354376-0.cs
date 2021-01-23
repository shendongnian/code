    var dict = new Dictionary<string, Person>(PersonList.Count);
            var uniqueList = new List<Person>();
            foreach (var p in PersonList)
            {
                var key = p.firstname + p.lastname + p.zipcode;
                if (!dict.ContainsKey(key))
                    dict.Add(key, p);
                else
                    dict[key] = null;
            }
            foreach (var kval in dict)
            {
                if (kval.Value != null)
                    uniqueList.Add(kval.Value);
            }
            return uniqueList;
