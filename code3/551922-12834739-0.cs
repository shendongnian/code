    System.Threading.Timer timer = new System.Threading.Timer(ThreadFunc, null, 0, 1000);
    private static void ThreadFunc(object state)
    {
        //Do work in here.
    }
