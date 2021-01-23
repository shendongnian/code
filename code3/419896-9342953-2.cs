    [WebMethod]
      public static IList<string> GetInsertsProgress()
      {
              var insertManager = new CsvInserts();
              return insertManager.GetInsertsProgress();
      }
