    public static void StoreError(string ErrorPage, Exception e)
        {
            try
            {
                eDurar.Models.db_edurarEntities1 DB = new Models.db_edurarEntities1();
                eDurar.Models.ErrorTable Err = new eDurar.Models.ErrorTable();
                Err.ErrorPage = ErrorPage;
                if (e.Message != null)
                {
                    Err.ErrorDetails = e.Message;
                }
                if (e.InnerException != null)
                {
                    Err.InnerException = e.InnerException.Message.ToString();
                }
                Err.Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                DB.ErrorTables.AddObject(Err);
                DB.SaveChanges();
    }
