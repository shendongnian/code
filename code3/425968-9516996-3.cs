    var names = new[] {"Name1", "Name2"};
    
    var ctx = new DatabaseContext("EFPlayingEntities");
    var result = ctx.As
        .Where(a => !a.Bs.Select(b => b.SomeName).Except(names).Any());
