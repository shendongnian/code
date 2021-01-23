    internal class WriteToLockedFile
        {
    		internal static string Uri { get; set ; }
            private static readonly object _syncObject = new object();
    
            public static void WriteToFile(string logMessage)
            {
                using (var stream = TextWriter.Synchronized( File.AppendText(Uri)))
                {
                    lock (_syncObject) 
    				{
    					stream.WriteLine(" {0}", logMessage); stream.Flush(); 
    				}
                }
            }
        }
