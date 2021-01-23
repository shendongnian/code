            A a = new A(5);
            Console.WriteLine(a.HasChanged);  //false
            a.Value = 6;
            Console.WriteLine(a.HasChanged);  //true
            a.HasChanged = false;
            Console.WriteLine(a.HasChanged);  //false
