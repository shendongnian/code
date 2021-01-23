    public string RandomStatusTypes()
     {
         List<string> statusTypes = new List<string> { "ACTIVE", "INACTIVE", "PROSPECT", "SUSPENDED" };
         Random randStatus = new Random();
         int index = randStatus.Next(0, statusTypes.Count);
         return statusTypes[index];
     }
