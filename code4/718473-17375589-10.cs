            class Controller {
               private DbRepository _repository;
               public Controller() {
                 _repository = GlobalServiceLocator.Get<DbRepository>()
               }
        
               // ... some methods that uses _repository
            }
