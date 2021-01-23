    foreach (GenericType console in consoleList)
    {
        if (console.HaveGame(a, ref indexResult))
        {
            title = console.GetTitle()[indexResult];
            Results.SetTitle(title);
            id = console.GetId()[indexResult];
            Results.SetId(id);
            price = console.GetPrice()[indexResult];
            Results.SetPrice(price);
        }
    }
