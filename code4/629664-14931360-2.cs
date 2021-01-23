        Dictionary<int , string> dictionary = new Dictionary<int, string>();	
        for (int i = 0; i < tables.Count(); i++)
        {
            dictionary.Add(i, tables[i].TableName);
            var s = tables[i].TableName;
            Console.WriteLine(i+". "+s);
        }
        Console.WriteLine("Choose index to open");
        string str = Console.ReadLine();
        int number = Convert.ToInt32(str);  
          
        // Get the tablename like:
        string tablename = dictionary[number];
   
