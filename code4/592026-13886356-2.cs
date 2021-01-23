    public struct ION
    {
        public Single a0    ;
        public Single a1    ;
        public Single a2    ;
        public Single a3    ;
        public Single b0    ;
        public Single b1    ;
        public Single b2    ;
        public Single b3    ;
        public Double A1    ;
        public Double A0    ;
        public UInt32 Tot   ;
        public Int16  Wnt   ;
        public Int16  DtLS  ;
        public Int16  WnLSF ;
        public Int16  DN    ;
        public Int16  DtLSF ;
        public Int16  Wn    ;
        public UInt32 Tow   ;
        public Int16  bulwn ;
        public UInt32 bultow ;
        public UInt16 checksum
        {
            get
            {
                byte[][] raw =
                {
                    BitConverter.GetBytes( a0     ) ,
                    BitConverter.GetBytes( a1     ) ,
                    BitConverter.GetBytes( a2     ) ,
                    BitConverter.GetBytes( a3     ) ,
                    BitConverter.GetBytes( b0     ) ,
                    BitConverter.GetBytes( b1     ) ,
                    BitConverter.GetBytes( b2     ) ,
                    BitConverter.GetBytes( b3     ) ,
                    BitConverter.GetBytes( A1     ) ,
                    BitConverter.GetBytes( A0     ) ,
                    BitConverter.GetBytes( Tot    ) ,
                    BitConverter.GetBytes( Wnt    ) ,
                    BitConverter.GetBytes( DtLS   ) ,
                    BitConverter.GetBytes( WnLSF  ) ,
                    BitConverter.GetBytes( DN     ) ,
                    BitConverter.GetBytes( DtLSF  ) ,
                    BitConverter.GetBytes( Wn     ) ,
                    BitConverter.GetBytes( Tow    ) ,
                    BitConverter.GetBytes( bulwn  ) ,
                    BitConverter.GetBytes( bultow ) ,
                } ;
                byte[] cooked = raw.SelectMany( x => x ).ToArray() ;
                uint  accumulator = 0 ;
                
                for ( int i = 0 ; i < cooked.Length ; i+= 2 )
                {
                    ushort value = BitConverter.ToUInt16( cooked , i ) ;
                    accumulator += value ;
                }
                return (ushort) accumulator ;
            }
        }
        
    }
