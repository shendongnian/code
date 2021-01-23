        public DisposeChain<DataContext> GetCDisposeChain()
        {
            var a = new DisposeChain<XmlWriter>(XmlWriter.Create((Stream)null));
            var b = a.Next(aItem => new SqlConnection());
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
