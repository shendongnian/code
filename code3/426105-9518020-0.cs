    private int counter;
    private readonly object locker = new object();
    public void IncrementCounter()
    {
        lock (this.locker)
        {
           this.counter++;
           Console.WriteLine(counter); 
        }
    }
    public int GetCounter()
    {
        lock (this.locker)
        {
           return this.counter;
        }
    }
