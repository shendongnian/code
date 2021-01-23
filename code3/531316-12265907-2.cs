        void SomeMethod()
        { 
         object o1 = new Object();
         object o2 = new Object();
         o1.ToString();
         GC.Collect(); // this forces o2 into Gen1, because it's still referenced
         o2.ToString();
        }
        
