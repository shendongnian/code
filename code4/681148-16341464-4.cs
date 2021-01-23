    var desired = File.ReadLines("Load.txt")
                      .Take(110)  // "And I want to keep 1-110" -- OP
                      .Select(line => UpdateLine(line));  // "And I also want to update variables between 1-110" -- OP
    
    File.WriteAllLines("new.txt", desired);
    ...
   
    static string UpdateLine(string given)
    {
         var updated = given;
         // other ops
         return updated;
    }
