    foreach (String procedure in storedProcedures)
    {
        Console.WriteLine("Current Procedure: \"" + procedure + "\"");
        String[] split = procedure.Split(',');
    
        Console.WriteLine("Split Length: " + split.Length.ToString());
    
        for (int i = 0; i < myArray.Length; i++)
            Console.WriteLine(i.ToString() + ") " + split[i]);
    }
