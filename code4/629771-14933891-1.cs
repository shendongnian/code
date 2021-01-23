    using System.IO; 
    using System.Linq
    
    var file = Directory.GetFiles("C:\\First\\Second\\").FirstOrDefault();
        
    if (file != null)
    {
        var fileName = Path.GetFileName(file);
    }
