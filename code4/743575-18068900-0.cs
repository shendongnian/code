    public class MyClass
    {
    
        Public MySubClass MySubClass {get;set;}
        Public MySubClass2 MySubClass2 {get;set;}
    
        public class MySubClass
        {
            public static int MySubInt { get; set; }
            public static string MySubStr { get; set; }
        }
    
        public class MySubClass2
        {
            public static int MySubInt2 { get; set; }
            public static string MySubStr2 { get; set; }
        }
    
        public static int MyInt { get; set; }
        public static string MyStr { get; set; }
    }
