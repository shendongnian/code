    private static readonly Regex rxNameSuffix = new Regex( @"^(?<name>.+)(?<suffix>\d*)$" ) ;
    string GenerateName( string name , IEnumerable<string> existingNames )
    {
        if ( string.IsNullOrWhiteSpace(name) ) throw new ArgumentException("name") ;
        int? maxSuffix = existingNames.Select( s => {
                Match m = rxNameSuffix.Match(s) ;
                if ( !m.Success ) throw new InvalidOperationException("that shouldn't have happened") ;
                string pfx = m.Groups["name"].Value ;
                int?   sfx = m.Groups["suffix"].Value.Length == 0 ? (int?)null : int.Parse( m.Groups["suffix"].Value ) ;
                return new Tuple<string,int?>( pfx , sfx ) ;
            })
            .Where( x => name.Equals( x.Item1 , StringComparison.OrdinalIgnoreCase) )
            .Aggregate( (int?)null , (acc,x) => {
                int? newacc ;
                if ( !x.Item2.HasValue ) return acc ;
                return !acc.HasValue || acc.Value < x.Item2.Value ? x.Item2 : acc ;
            }) ;
        int? suffix = maxSuffix.HasValue ? maxSuffix+1 : null ;
        return name + ( suffix.HasValue ? suffix.ToString() : "" ) ;
    }
