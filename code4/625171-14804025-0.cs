    using System.Linq;
    
    var grouppingByLocation = users.GroupBy(u => u.LocationID);
    foreach (var g in grouppingByLocation)
    {
         Console.WriteLine("Location id: {0}", g.Key);
         foreach (var u in g)
         {
              Console.WriteLine("User id: {0}", u.ID);
         }
    }
