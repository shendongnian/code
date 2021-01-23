    IEnumerable<Control> FindRecursive( Control c, Func<Control,bool> predicate )
    {
        if( predicate( c ) )
            yield return c;
    
        foreach( var child in c.Controls )
        {
            if( predicate( c ) )
                yield return c;
        }
    
        foreach( var child in c.Controls )
            foreach( var match in FindRecursive( c, predicate ) )
               yield return match;
    }
