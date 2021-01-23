    unsafe static void Main()
    {
        int i = Marshal.SizeOf(typeof(General));
        General obj = new General { CentralName = "abc", ProjectName = "def" },
                clone;
        byte* a = stackalloc byte[i];
        
        IntPtr ptr= new IntPtr(a);
        Marshal.StructureToPtr(obj, ptr, false);
        clone = (General) Marshal.PtrToStructure(ptr, typeof(General));
        Console.WriteLine(clone.CentralName); // abc
        Console.WriteLine(clone.ProjectName); // def
    }
