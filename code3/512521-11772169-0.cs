    public void m() {
        Console.WriteLine("Parallelable code sample");
        [Parallel("Begin of a parallel block")] {
            Console.WriteLine("Code exec by the main thread");
            [Process("First process")] { /∗ Computation here ∗/ }
            [Process] { /∗ Computation here ∗/ }
        }
        Console.WriteLine("Here is sequential");
    }
