    using (var command = connection.CreateCommand())
    {
        command.CommandText = "SELECT * FROM Table1";
        
        var conditions = "";
        if (condition1)
        {    
            conditions += "Col1=@val1 AND ";
            command.AddParameter("val1", 1);
        }
        if (condition2)
        {    
            conditions += "Col2=@val2 AND ";
            command.AddParameter("val2", 1);
        }
        if (condition3)
        {    
            conditions += "Col3=@val3 AND ";
            command.AddParameter("val3", 1);
        }
        if (conditions != null)
            command.CommandText += " WHERE " + conditions.Remove(conditions.Length - 5);
    }
