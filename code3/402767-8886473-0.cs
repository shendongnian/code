    var info = new String[5]{"6,j", "7,d", "12,s", "4,h", "14,s" };
    foreach (var item in info.OrderByDescending (x => 
                                       int.Parse(x.Substring(0, x.IndexOf(',')))))
    {
    	Console.WriteLine(item);
    }
