    namespace LocksAnimal {
      [Serializable()]
      public class Animal {
        private string name;
        public Animal() {
          name = "Lock";
        }
        public string GetName() {
    #ifdef PocketPC
          return name + " (Mobile Version)";
    #else
          return name + " (Webservice Version)";
    #endif
        }
      }
    }
