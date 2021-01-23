    using System.Text.RegularExpressions;
    using System.Linq;
    var regex=new Regex("[^A-Za-z0-9()/]");
    var toDisplay=string.Join("",regex.Matches(testString).OfType<Match>().Select(x=>x.Value).ToArray());
 
