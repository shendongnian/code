    class Attachvariable : MasterClass {
    
      private Hook<int> userId;
      private Hook<string> position;
    
      private Attachvariable() : base() {
        userId = AddHook("userID", 0);
        position = AddHook("position", String.Empty);
      }
    
      public Attachvariable(int id, string pos) : this() {
        userId.Value = id;
        position.Value = pos;
      }
    
    }
