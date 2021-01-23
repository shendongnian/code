    private volatile object _lockObj = new Object();
    public void WriteToFile( )
    {
        var file = "C:\\AsyncTest.txt";
        lock (_lockObj)
        {
            using (StreamWriter writer = File.AppendText( file ))
            {
                writer.WriteLine( "A simulated entry" );
            }
        }
    }
