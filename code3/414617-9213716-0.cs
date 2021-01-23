    foreach (DataRow row in dt.Rows) // Loop over the rows.
    {
        Console.WriteLine("--- Row ---"); // Print separator.
        foreach (var item in row.ItemArray) // Loop over the columns.
        {
            Console.Write("Item: "); // Print label.
            Console.WriteLine(item); 
            /// the Type of item will be whatever you defined when you
            /// called ClassBuilder.AddField() (String in your example)
        }
    }
    Console.ReadLine();
