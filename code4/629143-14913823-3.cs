    var list1 = new List<AvailableSlot>
    {
        new AvailableSlot { DateTime = new DateTime(2013, 2, 1), Name = "Alpha" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 2), Name = "Bravo" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 3), Name = "Charlie" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 1), Name = "Delta" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 2), Name = "Echo" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 3), Name = "Foxtrot" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 4), Name = "Golf" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 5), Name = "Hotel" }
     };
    
     var list2 = new List<AvailableSlot>
     {
        new AvailableSlot { DateTime = new DateTime(2013, 2, 1), Name = "Apple" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 2), Name = "Bannana" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 3), Name = "Cookie" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 1), Name = "Dog" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 2), Name = "Egg" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 3), Name = "Friend" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 4), Name = "Goat" },
        new AvailableSlot { DateTime = new DateTime(2013, 2, 5), Name = "Hi" }
    };
    // to include all DateTimes from both lists:
    var list3 = list1.Union(list2);
    // or to include only DateTimes that appear in both lists:
    //var list3 = list1.Where (l => list2.Where (li => l.DateTime == li.DateTime).Any ())
    //	.Union(list2.Where (l => list1.Where (li => l.DateTime == li.DateTime).Any ()));
    var groupedItems = from slot in list3
        group slot by slot.DateTime into grp
        select new AvailableSlot2 {
            DateTime = grp.Key,
            Names = grp.Select (g => g.Name).ToArray()
        };
    foreach(var g in groupedItems)
    {
        Console.WriteLine(g.DateTime);
        foreach(var name in g.Names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("---------------------");
    }
