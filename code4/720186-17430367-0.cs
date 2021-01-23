        private class Example 
        {
            public string xvalue { get; set; }
        }
        //this will give you matches per column for any amount of chars
        public static Dictionary<char, int[]> GetCount(IEnumerable<Example> matchAgainst,params char[] matchs)
        {
            //maybe there is an easier way to do this in linq I am not sure
            List<string> flattenedColumns = new List<string>();
            foreach ( var target in matchAgainst ) 
            {
                for ( int i = 0 ; i < target.xvalue.Length ; i++ )
                {
                    if ( flattenedColumns.Count <= i )
                    {
                        flattenedColumns.Add ( string.Empty );
                    }
                    flattenedColumns [ i ] += target.xvalue [ i ];
                }
            }
            //now compose based on the chars
            return ( from c in matchs
                     select new
                         {
                             CharTarget = c ,
                             Counts = ( from col in flattenedColumns
                                        select col.Count ( ( ch ) => ch == c ) ).ToArray ( )
                         } ).ToDictionary ( rslt => rslt.CharTarget , rslt => rslt.Counts );
        }
        public static void Do ( ) 
        {
            string curr = "";
            List<Example> exampleList = new List<Example> ( );
            for(int i=0;i<10;i++)
                for(int j=0;j<10;j++)
                    for ( int k = 0 ; k < 10 ; k++ ) 
                    {
                        curr= i+""+j+""+k;
                        exampleList.Add ( new Example { xvalue = curr } );
                    }
            var matches = GetCount ( exampleList , '1' , '2' , '3' );
            var var1Col1 = matches [ '1' ] [ 0 ];
            var var2Col1 = matches [ '2' ] [ 0 ];
            //...
        }
