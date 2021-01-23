    class PrinterData
    {
       public string Make { get; set; }
       public string Model { get; set; }
    }
        
    List<PrinterData> printers = ...
    
    if (printers.All(p => ! (p.Make == "" || p.Model == "")) )
      ...
