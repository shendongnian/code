    class PrinterData
    {
       public string Make { get; set; }
       public string Model { get; set; }
    }
        
    PrinterData[] printers = new PrinterData[3];  //or use a List<>
    printers[0] = new PrinterData { Make = "PH", Model = "1A" };
    ...
    
    if (printers.All(p => ! (p.Make == "" || p.Model == "")) )
      ...
