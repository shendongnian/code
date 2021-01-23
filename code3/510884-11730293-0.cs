        void thMethod()
        {
            while (_i < 100)
            {
                Thread.Sleep((new Random()).Next(1, 500));
                Application.DoEvents();
                lock(this)
                {
                    Console.WriteLine(_i);
                    _i++;
                }
            }
        }
