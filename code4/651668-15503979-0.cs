    private void StartAuction()
    {
        DateTime closeDate = DateTime.Parse(Console.ReadLine());
        DateTime closeDateTime = closeDate.Date + DateTime.Now.TimeOfDay;
        ...
    }
