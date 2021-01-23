    using System.Text.RegularExpressions;
    
    string cStr = "user Id=abc, database=DDD, Password=mypasswd";
    Console.WriteLine(cStr);
    
    Regex r = new Regex("(?<=database=)(.+?)(?=,)");
    cStr = r.Replace(cStr, "NewDatabaseName");
    
    Console.WriteLine(cStr);
