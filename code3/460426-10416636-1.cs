       int i = 10;
       string k = "Test";
       string t1 = System.String.Concat((object)i, (string)k);
       Console.WriteLine(t1);
       string t2 = System.String.Concat((string)k, (object)i);
       Console.WriteLine(t2);
