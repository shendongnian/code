     List<Foo> sc = new List<Foo>();
     sc.Add(new Foo()
     {
        ID = 0,
        Name = "Michael"
     });
     sc.Add(new Foo()
     {
        ID = 2,
        Name = "Natasha"
     });
     sc.Add(new Foo()
     {
        ID = 1,
        Name = "Casandra"
     });
     List<string> dt = new List<string>(); //For testing replaced just by string.
     dt.Add("Michael");
     dt.Add("Natasha");
     dt.Add("Casandra");
     var ordered = dt.Select(i => sc.First(c => c.Name == i)).OrderBy(i => i.ID);
