                        public List<Post> Search(string criteria,int x)
        {
            List<string> searchKeys = criteria.Split(' ').ToList<string>();
            _db = _db.Where(p => p.IsActive).ToList();
            foreach (string str in searchKeys)
            {
                _db = _db.Where(p => p.Location.Any(j => j.ToString().Contains(str)
                        || p.PostText.Any(y => y.ToString().Contains(str)
                        || p.Weather.Any(z => z.ToString().Contains(str))))).ToList();
            }
            return _db.OrderByDescending(p => p.PostDate).Take(x).ToList();
        }
