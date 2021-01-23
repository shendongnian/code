    static void Main( string[] args )
    {
        using( var inFs = File.OpenRead( @"C:\input.txt" ) )
        using( var reader = new StreamReader( inFs ) )
        using( var outFs = File.Create( @"C:\output.txt" ) )
        using( var writer = new StreamWriter( outFs ) )
        {
            int cur;
            char last = '0';
            while( ( cur = reader.Read() ) != -1 )
            {
                char next = (char)reader.Peek();
                char c = (char)cur;
                if( c != '\n' || last == '\r' )
                    writer.Write( c );
    
                last = c;
            }
        }
    }
   
