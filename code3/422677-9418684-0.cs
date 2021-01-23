    public void ThreadingMethod()
    {
        var myList = new List<MyClass> { new MyClass("test1"), new MyClass("test2") };
    Parallel.ForEach(myList, new ParallelOptions() { MaxDegreeOfParallelism = 100 },
             (myObj, i, j) =>
             {
                 MyMethod(myObj);
             });
    }
