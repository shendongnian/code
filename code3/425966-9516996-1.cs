    var names = new[] {"Name1", "Name2"};
    
    var ctx = new DatabaseContext("EFPlayingEntities");
    var result = ctx.As
        .Where(a => !names.Except(a.Bs.Select(b => b.SomeName)).Any());
