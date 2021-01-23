    void FrobAll()
    {
        for(int i = 0; i < 100; ++i)
        {
            FrobAsync(i); // somehow get a started task for doing a Frob(i) operation on this thread
            System.Windows.Forms.Application.DoEvents();
        }
    } 
