    using System.Text.RegularExpressions;
    using System.Linq;
    var str="asd fds 1.4#3";
    var regex=new Regex("([A-Za-z]+)|([0-9]+)|([.#]+)|(.+?)");
    
    var result=regex.Matches(str).OfType<Match>().Select(x=>x.Value).ToArray();
