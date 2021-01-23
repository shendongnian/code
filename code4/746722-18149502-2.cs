      [Test]
        public void TestGenericRepository()
        {
            IList<A> aList = new List<A>();
            aList.Add(new A() { Id = 1, name = "George", city = "Chicago"});
            aList.Add(new A() { Id = 2, name = "Bill", city = "Toledo" });
           
            List<B> bList = new List<B>(); 
            
            bList.Add(new B() {Id= 1, Nom = "Nathalie", ville = "Paris"});
            bList.Add(new B() {Id = 2, Nom = "Michelle", ville = "Lyon"});
            GenericRepositoryExample repository = new GenericRepositoryExample();
            repository.Save<A>(aList,HelperClass.EnglishSave);
            repository.Save<B>(bList,HelperClass.FrenchSave);
            
        }
