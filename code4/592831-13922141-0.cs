    var intersects = 
        data.Where(a => data
            .Any(b => 
                IsBetween(a.Start, b.Start, b.End) // <-- this is the test you did
                || IsBetween(a.End, b.Start, b.End) // <-- the missing other end
    //          || IsBetween(b.Start, a.Start, a.End) // potentially necessary
    //          || IsBetween(b.End, a.Start, a.End) // potentially necessary
            ));
