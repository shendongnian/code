    public class MyOtherClass {
       // only this object can set this.
       public int Level {
          get; private set; 
       }
       // only things in the same assembly can set this.
       public string Name {
          get; internal set;
       }
    }
