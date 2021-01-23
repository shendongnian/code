    var o = beatles
        .OrderBy( x => x.id )
        .GroupBy( x => x.inst )
        .Select( group => new { Group = group, Count = group.Count() } )
        .SelectMany( groupWithCount =>
            groupWithCount.Group.Select( b => b)
            .Zip(
                Enumerable.Range( 1, groupWithCount.Count ),
                ( j, i ) => new { j.inst, j.name, RowNumber = i }
            )
        );
            
    foreach (var i in o)
    {
        Console.WriteLine( "{0} {1} {2}", i.inst, i.name, i.RowNumber );
    }
