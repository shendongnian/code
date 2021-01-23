      public static List<BenchmarkListSqr> GetBenchmarkListSqr(string currencyCode)
      {
         return 
            MakeHttpQuery(
               CreateDataService()
               .BenchmarkList
               .Where(bm => bm.Currency == currencyCode)
               .ToString())
            .Select(x => new BenchmarkListSqr(
               x.Currency, 
               x.AssetClass, 
               ToNullDateTime(x.AvailableFromDate), 
               x.ID, 
               ToNullDateTime(x.InceptionDate), 
               x.Name, 
               x.Region, 
               ToNullDecimal(x.ShareID)))
            .ToList();
      }
