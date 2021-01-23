    public static string GetString( string hex )
        {
            byte[ ] raw = new byte[ hex.Length / 2 ];
            for( int i = 0; i < raw.Length; i++ )
            {
                byte convertToByte = Convert.ToByte( hex.Substring( i * 2, 2 ), 16 );
                raw[ i ] = convertToByte;
            }
            var result = Encoding.UTF8.GetString( raw ).Replace( ( ( char ) 0 ).ToString( ), "" );
            return result;
        }
