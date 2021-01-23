    using System.Linq;
    
    string word = "soHaMH";
    var capChars = word.Where(c => char.IsUpper(c)).Select(c => c);
    char capChar = capChars.FirstOrDefault();
    int index = word.IndexOf(capChar); 
    
    
