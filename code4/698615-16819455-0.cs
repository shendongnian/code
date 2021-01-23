                n = 1;
            i = 1;
            n = ++n - new Nullable<int>(i--);
            Console.WriteLine("With Nullable<int> n = {0}", n); //outputs n = 2
            Console.ReadKey();
