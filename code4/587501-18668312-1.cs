    class ClassA {
       public int Id { get; private set; }
       public string name { get; private set; }
       public ClassB myObjectB { get; set; }
       public ClassA(int pId, string pName) {
          Id = pId;
          name = pName;
       }
    }
    class ClassB {
       public int Id { get; private set; }
       public string name { get; private set; }
    
       public ClassB(int pId, string pName) {
          Id = pId;
          name = pName;
       }
    }
