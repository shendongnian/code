        public DisposeChain<DataContext> GetCDisposeChain()
        {
            var a = new DisposeChain<DataContext>(new DataContext(""));
            var b = a.Next(aItem => new DataContext(""));
            var c = b.Next(bItem => new DataContext(""));
            return c;
        }
        public void Test()
        {
            using (var cDisposer = GetCDisposeChain())
            {
                var c = cDisposer.Item;
                //do stuff with c;
            }
        }
