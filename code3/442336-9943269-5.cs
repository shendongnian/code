    private void button1_Click(object sender, EventArgs e)
    {
        new Thread(new ThreadStart(delegate()
        {
            AllocateConsole();
            for (uint i = 0; i < 1000000; ++i)
            {
                Console.WriteLine("Hello " + i);
            }
     
            DeallocateConsole();
        })).Start();
    }
    [Conditional("DEBUG")]
    private void AllocateConsole()
    {
        AllocConsole();
    }
     
    [Conditional("DEBUG")]
    private void DeallocateConsole()
    {
        FreeConsole();
    }
