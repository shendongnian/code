    public interface IPrinter
    {
       void Send();
       string Name { get; }
    }
    
    public class PrinterType1 : IPrinter
    {
      public void Send() { /* send logic here */ }
      public string Name { get { return "PrinterType1"; } }
    }
    
    public class PrinterType2 : IPrinter
    {
      public void Send() { /* send logic here */ }
      public string Name { get { return "Printertype2"; } }
    
      public string IP { get { return "10.1.1.1"; } }
    }
    
    
    // ...
    // then to use it
    var printers = new List<IPrinter>();
    
    printers.Add(new PrinterType1());
    printers.Add(new PrinterType2());
    
    foreach(var p in printers) { p.send(); }
