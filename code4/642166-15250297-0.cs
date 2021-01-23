            int y = 1;
            Action one = new Action(() =>
            {
                Console.WriteLine(y);//Outputs 1
                y = 2;
            });
            Action two = new Action(() =>
            {
                Console.WriteLine(y);//Outputs 2.  Working with same Y
                y = 1;
            });
            var t1 = Task.Factory.StartNew(one);
            t1 = Task.Factory.StartNew(two);
            t1.Wait();
            t1 = Task.Factory.StartNew(one);
            t1.Wait();
            t1 = Task.Factory.StartNew(two);
            Console.Read();
