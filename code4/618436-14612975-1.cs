    class Person
    {
        public string name;
        public string address;
        public string city;
        public string state;
        public string zip;
    
        public string this[int index] { //SPECIAL PROPERTY INDEXERS
            get {
               if(index == 0)
                  return name;
               else if(index == 1)
                  return address;
               ...
            }
            set {
               if(index == 0)
                  name = value;
               else if(index == 1)
                  address = value;
               ...
            }
        }
    }
