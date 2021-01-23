        static object syncObj = new object();
        static void func(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                lock (syncObj)
                {
                    Console.WriteLine(string.Format("This is function #{0} loop. counter - {1}", num, counter));
                    counter++;
                }
            }
        }
