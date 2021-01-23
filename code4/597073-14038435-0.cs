            int[] foo = new int[10];
            foreach (object o in foo)
            {
                Console.WriteLine(o.GetType());
                int? bar = o as int?;
                Console.WriteLine(bar);
            }
            Console.ReadKey();
