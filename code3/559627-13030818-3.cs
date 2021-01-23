        public IList<MyDbClass> GetMyDbClassData()
        {
            IList<MyDbClass> myDbClassData = null;
            using (IRepository<MyDbClass> repository = new DataRepository<MyDbClass>())
            {
                myDbClassData = (from x in repository.GetAll()
                                 select x).ToList();
            }
            return myDbClassData;
        }
