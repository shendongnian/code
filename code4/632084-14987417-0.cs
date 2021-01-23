    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Test {
       public static void Main(string[] args) {
            dynamic d1 = new System.Dynamic.ExpandoObject();
    	var dict = new Dictionary<int, dynamic>();
            dict[1] = d1;
            dict[1].FooBar = "Aniket";
            Console.WriteLine(dict[1].FooBar);
            dict[1].FooBar = new {s1="Hello", s2="World", s3=10};
            Console.WriteLine(dict[1].FooBar.s1);
            Console.WriteLine(dict[1].FooBar.s3);
       }
    }
