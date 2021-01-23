    List<int> LookFor<T>( IEnumerable<T> seq, T[ ] pattern )
            where T : IEquatable<T> {
    
        var partialMatches = new LinkedList<int>( );
        var matches = new List<int>( );
    
        int i = 0;
        foreach ( T item in seq ) {
            if ( item.Equals( pattern[ 0 ] ) )
                partialMatches.AddLast( 0 );
    
            var n = partialMatches.First;
            while(n != null) {
                if ( item.Equals( pattern[ n.Value ] ) ) {
                    n.Value += 1;
                    if ( n.Value == pattern.Length ) {
                        matches.Add( i - pattern.Length + 1 );
    
                        var next = n.Next;
                        partialMatches.Remove( n );
                        n = next;
    
                        continue;
                    }
                }
                else partialMatches.Remove( n );
    
                n = n.Next;
            }
    
            i += 1;
        }
    
        return matches;
    }
