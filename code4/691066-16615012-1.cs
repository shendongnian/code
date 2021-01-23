    static bool AddTextToFile( string someText , int maxAttempts )
    {
        if ( string.IsNullOrWhiteSpace(someText) ) throw new ArgumentOutOfRangeException( "someText"    ) ;
        if ( maxAttempts < 0                     ) throw new ArgumentOutOfRangeException( "maxAttempts" ) ;
            
        bool success = false ;
        int  attempts = 0 ;
            
        while ( !success )
        {
            if ( maxAttempts > 0 && ++attempts > maxAttempts ) { break ; }
            try
            {
                using ( Stream       s = File.Open( @"c:\log\my-logfile.txt" , FileMode.Append , FileAccess.Write , FileShare.Read ) )
                using ( StreamWriter sw = new StreamWriter(s,Encoding.UTF8) )
                {
                    sw.WriteLine("The time is {0}. The text is {1}" , DateTime.Now , someText );
                    success = true ;
                }
            }
            catch (IOException)
            {
                // the file is locked or some other file system problem occurred
                // sleep for 1/4 second and retry
                success = false ;
                Thread.Sleep(250);
            }
        }
            
        return success ;
    }
