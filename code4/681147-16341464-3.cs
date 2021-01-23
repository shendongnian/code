    var desired = File.ReadLines("Load.txt")
                      .Take(110)
                      .Select(line => UpdateLine(line));
    
    File.WriteAllLines("new.txt", desired);
    ...
   
    static string UpdateLine(string given)
    {
         var updated = given;
         // other ops
         return updated;
    }
