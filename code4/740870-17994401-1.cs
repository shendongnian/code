    // To enqueue the write
    ThreadPool.QueueUserWorkItem(WriteToFile, "A simulated entry");
    
    // the lock
    private static object writeLock = new object();
    
    public static void WriteToFile( object msg ) {
        lock (writeLock) {
            var file = "C:\\AsyncTest.txt";
            // using (var writer = File.Exists( file ) ? File.AppendText( file ) : File.CreateText( file )) {
            // As written http://msdn.microsoft.com/it-it/library/system.io.file.appendtext(v=vs.80).aspx , File.AppendText will create the
            // file if it doesn't exist
            using (var writer = File.AppendText( file )) {
                writer.WriteLine( (string)msg );
            }
        }
    }
