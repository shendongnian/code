    class Fat{
        public string A();
        public int B(); 
        .
        public void EatMeat()
        .
        public void Z();
    }
    class JennyCraig{
      private Fat f = Fat();
      public string A(){
         return f.A();
      }
      public void Z(){
         return f.Z();
      }
    class Atkins{
        public Fat f = Fat();
        public void EatMeat(){
             return f.EatMeat();
        }
    }
