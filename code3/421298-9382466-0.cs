           List<int> RecentClientsArray = Array.ConvertAll(RecentClients.Split(','), n => Convert.ToInt32(n)).ToList();
           // other code
           var RecentClientList = (from c in db.ClientNames
                                   where RecentClientsArray.Contains(c.ConsumerID)
                                   orderby RecentClientsArray.IndexOf(c.ConsumerID) descending
                                   select new { FullName = c.LastName + ", " + c.FirstName + " #" + c.ConsumerID, recentConsumerID = c.HorizonID });
