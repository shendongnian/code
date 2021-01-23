    private void StartAuction()
    {
        DateTime closeDate = DateTime.Parse(Console.ReadLine());
        DateTime closeDateAtCurrentTime = closeDate.Date + DateTime.Now.TimeOfDay;
        ...
    }
