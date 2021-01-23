    int[] listA = new int[6000]; // 3000 time * 2 seconds
    int i = 0;
    // method is called externally 3000 times per second
    void ProducerThread(int a)
    {
        if (Monitor.TryEnter(listA)) // If true, consumer is in cooldown.
        {
            listA[i] = a;
            i++;
            Monitor.Exit(listA);
        }
    }
    void ConsumerThread()
    {
        Monitor.Enter(listA); // Acquire thread lock.
        while (true)
        {
            Monitor.Wait(listA, 2000); // Release thread lock for 2000ms, automaticly retake it after Producer released it.
            foreach (int a in listA) { } //Processing...
            listA = new int[6000];
            i = 0;
        }
    }
