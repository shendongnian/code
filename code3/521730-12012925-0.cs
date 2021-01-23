    static void Main( string[] args )
    {
        string[][] jagged = new string[][] { new string[] { "alpha" ,                                              } ,
                                                new string[] { "bravo" , "charlie" ,                                  } ,
                                                new string[] { "delta" , "echo"    , "foxtrot" ,                      } ,
                                                new string[] { "golf"  , "hotel"   , "india"   , "juliet" ,           } ,
                                                new string[] { "kilo"  , "lima"    , "mike"    , "nancy"  , "oscar" , } ,
                                            } ;
        string[,]  rectangular = RectArrayFromJagged<string>( jagged ) ;
            
        return;
    }
    
    public static T[,] RectArrayFromJagged<T>( T[][] a )
    {
        int  rows  = a.Length;
        int  cols  = a.Max( x => x.Length );
        T[,] value = new T[ rows , cols ] ;
        
        value.Initialize() ;
        
        if ( typeof(T).IsPrimitive )
        {
            int elementSizeInOctets = Buffer.ByteLength(value) / value.Length ;
            for ( int i = 0 ; i < rows ; ++i )
            {
                int rowOffsetInOctets = i * cols    * elementSizeInOctets ;
                int rowLengthInOctets = a[i].Length * elementSizeInOctets ;
                Buffer.BlockCopy( a[i] , 0 , value , rowOffsetInOctets , rowLengthInOctets ) ;
            }
        }
        else
        {
            for ( int i = 0 ; i < rows ; ++i )
            {
                int rowLength = a[i].Length ;
                for ( int j = 0 ; j < rowLength ; ++j )
                {
                    value[i,j] = a[i][j] ;
                }
            }
        }
        return value ;
    }
