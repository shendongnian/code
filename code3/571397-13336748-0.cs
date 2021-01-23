    bSuccessful = TryDataBaseAction(dbEntities, out ErrorMessage,
    () =>
    {   
        List<Man> men = myQuery.OfType<Man>().ToList();
        Records = new string[men.Count, 2];
        
        for (int i = 0; i < Records.Count; i++)
        {
            Records[i, 0] = men[i].ManID.ToString();
            Records[i, 1] = men[i].Name;
        }
    });
