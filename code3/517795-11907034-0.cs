    static void Main()
    {
        // Create A instance and print its value
        A a = new A(50);
        a.Print();
        // Strand the A object (have nothing point to it)
        a = null;
        // Activate the garbage collector
        GC.Collect();
        // Add this to wait for the destructor to finish
        GC.WaitForPendingFinalizers();
        // Print A's value again
        B.IntA.Print();
    }
