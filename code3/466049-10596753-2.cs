        public int IDuser(string username)
        {
            int lastID;
            if (username=="Admin")
            {
                lastID=1;
                
            }
            else
            {
                lastID = _entities.Count();
            }
                
            return lastID;
        }
