    private class Row
    {
        public object[] Columns {get;set;}
    }
    public static Dictionary<object, int[]> GetCountByIndex(IEnumerable<Row> matchAgainst, params object[] matches)
    {
        bool firstTime = true;
        return
        ( from key in matches
            let flatCols = ( from Row row in matchAgainst select row.Columns ).Aggregate ( ( a , b ) =>
            {
                var retlen = a.Length;
                if ( b.Length > a.Length )
                    retlen = b.Length;
                object [ ] retv = new object [ retlen ];
                //use bool flag to determine first time objects are being aggregated
                if (!firstTime)
                {
                    //do every other join
                    for ( int i = 0 ; i < retlen ; i++ )
                    {
                        List<object> curr = null;
                        if ( i >= a.Length )
                        {
                            curr = new List<object> ( );
                        }
                        else
                        {
                            curr = a [ i ] as List<object>;
                        }
                        if ( i < b.Length )
                        {
                            curr.Add ( b [ i ] );
                        }
                        retv [ i ] = curr;
                    }
                }
                else
                {
                    //intialization
                    for ( int i = 0 ; i < retlen ; i++ )
                    {
                        List<object> curr = new List<object>( );
                        if ( i < a.Length )
                        {
                            curr.Add ( a [ i ] );
                        }
                        if ( i < b.Length )
                        {
                            curr.Add ( b [ i ] );
                        }
                        retv [ i ] = curr;
                    }
                    firstTime = false;
                }
                return retv;
            } )
            select new
            {
                Key = key ,
                Value = ( from object obj in flatCols
                        select ( ( List<object> ) obj ).Count ( c => key.Equals ( c ) ) ).ToArray ( )
            } ).ToDictionary ( keySel => keySel.Key , valSel => valSel.Value );
    }
