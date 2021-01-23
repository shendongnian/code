    public int RandomStatusTypes()
     {
         List<string> statusTypes = new List<string> { "ACTIVE", "INACTIVE", "PROSPECT", "SUSPENDED" };
         Random randStatus = new Random();
         return randStatus.Next(0, statusTypes.Count);
     }
