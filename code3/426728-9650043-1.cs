    public void ManageData()
    {
        foreach (var record in DAL.GetRecords())
        {
             record.IsUpdated = true;
             DAL.UpdateData();
        }
    }
