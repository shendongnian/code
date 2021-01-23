    string byteStr = input.Substring(2);
    byte[] bytes = new byte [ byteStr.Length / 2 ];
    for ( int i = 0, j = 0 ; i < byteStr.Length ; i += 2 , j++ )
    {
         bytes [ j ] = byte.Parse ( byteStr.Substring ( i , 2 ) , NumberStyles.HexNumber );
    }
    string str = Encoding.UTF8.GetString ( bytes );
    byte[] UTF32Bytes = Encoding.UTF32.GetBytes ( str );
