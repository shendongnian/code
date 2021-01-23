    public FileInfo[] RecentlyWrittenFilesWithin( string path , string searchPattern , DateTime dateFrom , DateTime dateThru )
    {
      if ( string.IsNullOrWhiteSpace( path ) ) {  throw new ArgumentException("invalid path" , "path" );}
      DirectoryInfo root = new DirectoryInfo(path) ;
      if ( !root.Exists ) {  throw new ArgumentException( "non-existent directory" , "path" ) ; }
      bool isDirectory = FileAttributes.Directory == ( FileAttributes.Directory & root.Attributes ) ;
      if ( isDirectory ) {  throw new ArgumentException("not a directory","path");}
      
      FileInfo[] files = root.EnumerateFiles( searchPattern , SearchOption.AllDirectories )
                             .Where( fi => fi.LastWriteTime >= dateFrom && fi.LastWriteTime <= dateThru )
                             .ToArray()
                             ;
      return files ;
    }
