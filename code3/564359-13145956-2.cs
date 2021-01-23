    static void Main( string[] args )
    {
        using( var inFs = File.OpenRead(@"C:\input.txt") )
        using( var reader = new StreamReader( inFs ) )
        using( var outFs = File.Create( @"C:\output.txt" ) )
        using( var writer = new StreamWriter( outFs ) )
        {           
            string line;
            while( (line = reader.ReadLine()) != null )
            {
                line = line.Replace( "\r", "" );
                line = line.Replace( "\n", "\r\n" );
                writer.Write( line );
            }
        }
    }
