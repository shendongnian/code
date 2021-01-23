    public static List<Computer> NetworkComputers()
    {
        List<Computer> lstComputers = new List<Computer>();
        DirectoryEntry root = new DirectoryEntry("WinNT:");
        foreach (DirectoryEntry computers in root.Children)
        {
            foreach (DirectoryEntry computer in computers.Children)
            {
                if (computer.Name != "Schema" && computer.SchemaClassName == "Computer")
                {
                    lstComputers.Add(new Computer() { Name = computer.Name });
                }
            }
        } 
    }
    
