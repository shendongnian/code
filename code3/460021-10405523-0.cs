    #if FOO
    partial class C 
    {
        // class!
        int @class = 123;
        string c = "class";
    }
    partial class C {}
    #else
    partial class D {}
    partial class D {}
    partial class D {}
    #endif
