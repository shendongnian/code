    interface IPersonRepository{
        IPerson GetPerson();
    }
    class PersonRepository : IPersonRepository{
        public IPerson GetPerson(){
            return GetDataFromDatabase();
        }
        private IPerson GetDataFromDatabase(){
            // Get data straight from database.
        }
    }
    class PersonRespositoryWithCaching : IPersonRepository{
        public IPerson GetPerson(){
            IPerson person = GetDataFromCache();
            // Is person in cache?
            if(person!=null){
                // Person found in cache.
                return person;
            }else{
                // Person not found in cache.
                person = GetDataFromDatabase();
                StoreDataInCache(person);
                return person;
            }
        }
        private IPerson GetDataFromCache(){
            // Get data from cache.
        }
        private IPerson GetDataFromDatabase(){
            // Get data straight from database.
        }
    }
    class Program{
        static void Main(){
            IPersonRepository repository = null;
            if(cachingEnabled){
                repository = new PersonRepositoryWithCache();
            }else{
                repository = new PersonRepository();
            }
            // At this point the program doesn't care about the type of
            // repository or how the person is retrieved.
            IPerson person = repository.GetPerson();
        }
    }
