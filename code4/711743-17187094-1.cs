    public readonly int[] a;
    ReadOnlyCollection<int> result = Array.AsReadOnly(a);
    public Class1()
    {
        a = new int[3];
        a[0] = 1;
        a[1] = 2;
        a[2] = 3;
       
    }
    public void Update()
    {
        result[0] = 10; // Compile Time Error Here
    }
    
