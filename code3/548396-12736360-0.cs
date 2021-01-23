    using (var writer = new StreamWriter("path"))
    {
       foreach(var line in File.ReadLines("path"))
       {
           if (string.IsNullOrWhiteSpace(line)) 
           { /**/ }
           else
           { /**/ }
       }
    }
