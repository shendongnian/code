    string pathToFile = "path-to-your-file" ;
    using ( Stream     s = File.Open( pathToFile , FileMode.Open , FileAccess.Read , FileShare.ReadWrite ) )
    using ( TextReader r = new StreamReader( s ) )
    {
        string fileContents = r.ReadToEnd() ;
        process( fileContents ) ;
    }
