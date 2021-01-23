    static void Main( string[] args )
    {
        using( var inFs = File.OpenRead(@"C:\input.txt") )
        using( var reader = new StreamReader( inFs ) )
        using( var outFs = File.Create( @"C:\output.txt" ) )
        using( var writer = new StreamWriter( outFs ) )
        {
            var guid = Guid.NewGuid().ToString();
            string line;
            while( (line = reader.ReadLine()) != null )
            {
                line = line.Replace( "\r\n", guid );
                line = line.Replace( "\n", "" );
                line = line.Replace( guid, "\r\n" );
                writer.Write( line );
            }
        }
    }
