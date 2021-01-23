    using System.Text.RegularExpressions;
    using System.Linq;
    var regex=new Regex("[A-Za-z0-9()/]");
    var toDisplay=regex.Replace(testString,string.Empty);
   
