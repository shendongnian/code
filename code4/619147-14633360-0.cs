        static string catch_processing ( Exception  e )
            {
            StringBuilder   sb = new StringBuilder ( );
            try 
                { 
                throw e; 
                } 
            catch ( PathTooLongException )
                {
                sb.Append (
                    "Supplied path is longer than the system-" +
                    "defined maximum length" );
                }
            catch ( ArgumentException )
                {
                sb.Append (
                    "Supplied path contains invalid characters, " +
                    "is empty, or contains only white spaces" );
                }
            catch ( UnauthorizedAccessException )
                {
                sb.Append (
                    "The caller does not have the " +
                    "required permission" );
                }
            : other catch blocks
            sb.AppendFormat ( "{0}{1}{2}{3}",
                              Environment.NewLine,
                              e.Message,
                              Environment.NewLine,
                              e.StackTrace );
            return ( sb.ToString ( ) );
            }
        
