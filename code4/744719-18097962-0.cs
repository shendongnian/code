        void go()
        {
            int i = 5;
            int i1 = i; //note this
            ThreadPool.QueueUserWorkItem(delegate
            {
                for (int j = 1; j <= 1000; j++)
                    Console.Write(i1); //and note this
            });
            for (int k = 1; k <= 1000; k++)
                i = k;
            Console.ReadLine();
        }
