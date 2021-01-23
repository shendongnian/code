    // Declare it somewhere
    delegate void DelegateType(string s);
    
    // The cast is required to make the code compile
    Test((DelegateType)((string s) => { MessageBox.Show(s); }));
    public static void Test(dynamic dynDelegate)
    {
        dynDelegate("hello");
    }
