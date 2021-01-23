    private static List<string> StatusTypes = new List<string>(){ "ACTIVE", "INACTIVE", "PROSPECT", "SUSPENDED" };
    private static Random randStatus = new Random();
    public string RandomStatusTypes()
    {
        int index = randStatus.Next(0, StatusTypes.Count);
        return StatusTypes[index];
    }
