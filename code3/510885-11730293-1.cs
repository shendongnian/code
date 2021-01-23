            while (_i < 100)
            {
                Thread.Sleep((new Random()).Next(1, 500));
                Application.DoEvents();
                lock(this)
                {
                    if (_i >= 100) break;
                    Console.WriteLine(_i);
                    _i++;
                }
            }
