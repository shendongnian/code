    Command getProcess = new Command("Get-Process");
    Command sort = new Command("Sort-Object");
    sort.Parameters.Add("Property", "VM"); 
    pipeline.Commands.Add(getProcess);
    pipeline.Commands.Add(sort);
