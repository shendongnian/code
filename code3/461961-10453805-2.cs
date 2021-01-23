            var query = session.Advanced.LuceneQuery<Asset, AssetsByExpirationDate>()
                .WhereBetween("ExpirationDate",DateTime.MinValue,new DateTime(2012, 6, 1));
            var assets = query.ToList();
            foreach(var asset in assets)
            {
                session.Delete<Asset>(asset);
            }
            session.SaveChanges();
