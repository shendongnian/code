    foreach (StuffId Id in Result.GetIdList())
    {
        if (Id.Level == 3)
        {
            Level3Id = Id.ToString();
        }
        if (Id.Level == 5)
        {
            Level5Id = Id.ToString();
        }
    }
