        public IEnumerable<Keyword> Get()
        {
            List<Keyword> data;
            using (TestDataContext dc = new TestDataContext())
            {
                data = dc.Keywords.ToList();
            } 
            // here you can do some operations with 'data'
            return data;
        }
