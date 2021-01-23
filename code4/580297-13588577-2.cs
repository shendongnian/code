    var excel = new Microsoft.Office.Interop.Excel.Application();
    var addIn = ex.AddIns.Add(filename);
    addIn.Installed = true;
    Console.WriteLine(addIn.IsOpen);
    
