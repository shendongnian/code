       public virtual HistoryData ReadFirst()
        {
            using (HistoryContainer db = new HistoryContainer())
            {
                return db.HistoryData.Where(x => x.MP == IpAddress).FirstOrDefault();
            }
        }
