        foreach (ArrayList k in l)
        {
            foreach (DynamicTableEntity dte in k)
            {
                if (tablebatchoperation == null)
                   tablebatchoperation = new TableBatchOperation();
                tablebatchoperation.Insert(dte);
                if (tablebatchoperation.Count == 100)
                {
                   table.ExecuteBatch(tablebatchoperation);
                   tablebatchoperation = new TableBatchOperation();
                }
            }
        }
        
        if (tablebatchoperation.Count > 0)
            table.ExecuteBatch(tablebatchoperation);
