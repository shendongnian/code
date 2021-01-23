    // To enqueue the write
    ThreadPool.QueueUserWorkItem(WriteToFile, "A simulated entry");
    
    // the lock
    private static object writeLock = new object();
    
    public static void WriteToFile( object msg ) {
        lock (writeLock) {
            var file = "C:\\AsyncTest.txt";
            using (var writer = File.Exists( file ) ? File.AppendText( file ) : File.CreateText( file )) {
                writer.WriteLine( (string)msg );
            }
        }
    }
