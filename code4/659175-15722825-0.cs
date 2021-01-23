            Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000000); // this line won't make UI freeze.
                });
            Thread.Sleep(5000000); // But this will certainly do.
