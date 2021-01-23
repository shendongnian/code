    var names = new[] {"Name1", "Name2"};
    var nameCount = names.Length;
    
    var ctx = new DatabaseContext("EFPlayingEntities");
    var result = ctx.As
        .Where(a => a.Bs
                     .Select(b => b.SomeName)
                     .Intersect(names)
                     .Count() == nameCount);
