    interface IMyAlgorithm {
      AbstractOutput DoSomething (InputData);
    }
    
    class ConcreteOutput : AbstractOutput {
      // Output for version XXX of your algorithm
    }
    
    class XXXAlgorithm {
      ConcreteOutput DoSomething (InputData inputData)
        // Version XXX of you alogorithm
      }
    }
    
    interface IPersistenceManager {
      Serialize(AbstractOutput output, string filename);
      AbstractOutput Deserialize(string filename)
    }
    
    class XXXPersistenceManager : IPersistenceManager {
      // Handle persistence for XXX hierarchy
    }
    
    class XXXTestFixture {
      void BuildObjectWithXXXAlgorithm() {
        IMyAlgorithm XXX = new XXXAlgorithm();
        // run XXX here
        AbstractOutput objXXX = XXX.DoSomething(new InputData());
        IPersistenceManager pmXXX = new XXXPersistenceManager();
        pmXXX.Serialize(objXXX);
      }
    
      void VerifyThatXXXWorkAsExpected() {
        IPersistenceManager pmXXX = new XXXPersistenceManager();
        AbstractOutput objXXX = pmXXX.Deserialize(path);
        // check object here
      }
    }
