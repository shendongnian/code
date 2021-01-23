        private void test()
        {
            var list = Enumerable.Range(0, 10)
                .ToObservable()
                .ObserveOn(Scheduler.ThreadPool)
                .SubscribeOn(Scheduler.ThreadPool)
                .Subscribe(i=>Go(),Done);
        }
        void Go()
        {
            Console.WriteLine("Hello");
        }
        void Done()
        {
            Console.WriteLine("Done");
        }
