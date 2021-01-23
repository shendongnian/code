            var query = session.Advanced.LuceneQuery<Asset, AssetsByExpirationDate>()
                .WhereBetween("ExpirationDate",DateTime.MinValue,new DateTime(2012, 6, 1));
            var queryString = query.ToString();
            session.Advanced.DatabaseCommands.DeleteByIndex(typeof(AssetsByExpirationDate).Name, new IndexQuery
            {
                Query = queryString
            });
