    Thread updateThread = new Thread(updateLoop);
    IEnumerable<Updateable> _updateableObjects;
    public static void Main()
    {
        updateThread.Start();
    } 
    private static function UpdateLoop()
    {
        while (true)
        {
            Parallel.ForEach(_updateableObjects, obj => obj.Update());
            Thread.Sleep(1000);
        }
    }
