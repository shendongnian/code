    public static class MyClass
    {
        public static Dictionary<string,SomeDisposableClass> dict = null;
        public static Dictionary<string,object> locks = null;
    
        static MyClass()
        {
             // populate the dictionary 
             locks = new Dictionary<string,object>();
             foreach (var key in dict.Keys)
             {
                 locks[key] = new object();
             }
        }
    
        public static void UseDictionary( string name )
        {
            var obj = dict[name];
            var sync = locks[name];
            lock(sync)
            {
                obj.DoSomething();
            }
        }
    }
