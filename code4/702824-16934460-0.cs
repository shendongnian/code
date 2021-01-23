    using System.Web;
    
    //...
    var test1 = "HELLO%20";
    var test2 = "hello";
    Console.WriteLine(HttpUtility.UrlDecode(test1).Trim().
               Equals(HttpUtility.UrlDecode(test2).Trim(),              
               StringComparison.InvariantCultureIgnoreCase));
