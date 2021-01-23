    var table = new ConsoleTable("one", "two", "three");
    table.AddRow(1, 2, 3)
         .AddRow("this line should be longer", "yes it is", "oh");
    
    table.Write();
