    eventReader = dbcommand.ExecuteReader();
    bool hasRow = eventReader.Read();
    if (hasRow)
    {
        for (int i = 0; i < checkboxEvent.Items.Count; i++)
        {
            ...
                ...
                while (hasRow)
                {
                    // Code in here to deal with each row
                    hasRow = eventReader.Read();
                }
        }
    }
