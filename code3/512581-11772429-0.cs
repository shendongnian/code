       public virtual HistoryData ReadFirst()
        {
            using (HistoryContainer db = new HistoryContainer())
            {
                return db.Where(x => x.MP == IpAddress).FirstOrDefault();
            }
        }
