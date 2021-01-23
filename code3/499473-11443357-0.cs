    string strID;
    string[] filesNFO = Directory.GetFiles( @"D:\Test\", "*.nfo", SearchOption.AllDirectories );
    
    foreach( string file in filesNFO )
    {
        var doc = XDocument.Load( file );
        strID = doc.Root.Element( "id" ) == null ? "" : doc.Root.Element( "id" ).Value;
    
        string directory = Path.GetDirectoryName( file );
        string infoNfo = Path.Combine( directory, "info.nfo" );
    
        using( var fs = new FileStream( infoNfo, FileMode.Create ) )
        using( var info = new StreamWriter( fs ) )
        {
            info.Write( "http://powerhostcrm.com/" + strID );
        }
    }
