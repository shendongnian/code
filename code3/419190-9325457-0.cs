            dynamic d = new ExpandoObject();
            d.Name = "MyNameIsTest";
            d.Age = 26;
            d.Weight = 62.5d;
            d.dosomethingforme = "blablabla ....";
            d.GreetMe = new Action(delegate()
            {
                Console.WriteLine("Hello {0}", d.Name);
            });
