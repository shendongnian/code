    public class MethodPicker 
        { 
            public string Name {get;set;}
        } 
    public static class Extensions
    {     
            private delegate string SomeFunc(MethodPicker item); 
            static readonly Dictionary<string, SomeFunc> test = new Dictionary<string, SomeFunc>(); 
     
            static Extensions() 
            { 
                test.Add("key1", Func1); 
                test.Add("key2", Func2); 
                test.Add("key3", Func3); 
            } 
            public string AsSpecialString(this MethodPicker obj) 
            { 
                string somestring = test[obj.Name].Invoke(obj); 
                return somestring; 
            } 
     
            string Func1(MethodPicker entity) 
            { 
                return "func1 runs"; 
            } 
     
            static string Func2(MethodPicker entity) 
            { 
                return "func2 runs"; 
            } 
     
            static string Func3(MethodPicker entity) 
            { 
                return "func3 runs"; 
            } 
    }
