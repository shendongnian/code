    [Parallel("Parallelable code sample", ACSIndex=1)]
    [Process("First process", ACSIndex=2)]
    [Process(ACSIndex=3)]
    public void m() {
        Console.WriteLine("Parallelable code sample");
        Annotation.Begin(1); { // [Parallel]
            Console.WriteLine("Code exec by the main thread");
            Annotation.Begin(2); /∗ [Process("First process")] ∗/ { · · · }
            Annotation.End(2);
            Annotation.Begin(3); /∗ [Process] ∗/ { · · · }
            Annotation.End(3);
        } 
        Annotation.End(1);
    }
