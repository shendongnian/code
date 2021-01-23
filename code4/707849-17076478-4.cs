    public List<Post> Search(string criteria, int x)
        {
            // Split all the search keys by space, so if you have "Search Word", you will get
            // the occurances of [Search] and also [Word]
            List<string> searchKeys = criteria.Split(' ').ToList<string>();
            // Filter active
            _db = _db.Where(p => p.IsActive);
            // Go through each key
            foreach (string str in searchKeys)
            {
                _db = _db.Where(p => p.Location.Contains(str)
                        || p.PostText.Contains(str)
                        || p.Weather.Contains(str));
            }
            // Return number wanted - and items will only be extracted here on the ToList()
            return _db.OrderByDescending(p => p.PostDate).Take(x).ToList();
        }
