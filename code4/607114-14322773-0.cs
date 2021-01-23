    foreach( var parm in parms )
    {
      if (dataColumnCollection.Contains(parm.Key))
      {
        var copy = parm;
        predicate = predicate.And( p => p[ copy.Key ] == copy.Value );
      }
