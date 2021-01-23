    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
    public void MyTestMethod()
    {
        IObservable<int> A = new List<int>() { 2, 3, 5, 10, 15 }.ToObservable();
        IObservable<int> B = new List<int>() { 1, 5, 6, 7, 11,12,21,22 }.ToObservable();
        Queue<int> BufferA = new Queue<int>();
        Queue<int> BufferB = new Queue<int>();
        Console.WriteLine("hello");
        A.MergeSort(B).Subscribe((v)=>{
            Console.WriteLine(v);
        });
        Thread.Sleep(10);
        
    }
