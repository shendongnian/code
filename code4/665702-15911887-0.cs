                List<MyClass> list = new List<MyClass>();
                list.Add(new MyClass { MyValue = "first" });
                list.Add(new MyClass { MyValue = "second" });
    
                foreach (var myClass in list)
                {
                    Console.WriteLine(myClass.MyValue);
                }
    
        
