    [StructLayout(LayoutKind.Sequential)] // To make type [Class A] blittable
    Class A
    {
        int x;    
    
        public A(int x)
        {
            this.x = x;
        }   
        ...
    }
    
    Class B
    {
        A a;
        public B(A a)
        {
            this.a = a;
        }    
    
        public A GetA()
        {
            return a;
        }
        ...
    }
    
    main()
    {
        var a = new A(10, 20);
        var b = new B(a);
        GCHandle gc = GCHandle.Alloc(objA, GCHandleType.Pinned); // Through GCHandle you can access the managed object from unmanaged memory.
        IntPtr add = gc.AddrOfPinnedObject();  //pointer
        Console.WriteLine(add.ToString());
    }
