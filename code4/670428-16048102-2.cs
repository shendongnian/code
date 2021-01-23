    static IEnumerable<FileInfo> FindFiles( IEnumerable<string> directories , string searchPattern )
    {
      DateTime     dtNow       = DateTime.Now.Date                ; // current date
      DateTime     dtFrom      = dtNow.AddDays( dtNow.Day - 1 )   ; // compute the first of the month @ start-of-day
      DateTime     dtThru      = dtFrom.AddMonths(1).AddTicks(-1) ; // compute the last of the month @ end-of-day
      string       childPattern = dtFrom.ToString( "yyMM*") ;
      return directories.Select( x => new DirectoryInfo( x ) )
                        .Where( x => x.Exists )
                        .SelectMany( x => x.EnumerateDirectories( childPattern , SearchOption.TopDirectoryOnly )
                                           .Where( subDir => {
                                               int dd ;
                                               int.TryParse( subDir.Name.Substring(4,2) , out dd ) ;
                                               return dd >= dtFrom.Day && dd <= dtThru.Day ;
                                             })
                        )
                        .SelectMany( subDir => subDir.EnumerateFiles( searchPattern , SearchOption.TopDirectoryOnly )
                                                     .Where( file => file.LastAccessTime >= dtFrom && file.LastAccessTime <= dtThru )
                        )
                        ;
    }
