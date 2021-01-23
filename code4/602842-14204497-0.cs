    var items = clientProgramList.Items.OfType<SPListItem>().Where(x =>
    {
        DateTime doa = x.GetValue<DateTime>("client1");
        DateTime dod = x.GetValue<DateTime>("client2");
        bool date = DateCompare.IsValidClient(enteredDate, endDate, doa, dod); 
        return date;
    });
    int count = items.Count();
