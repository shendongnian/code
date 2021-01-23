    public class Parent {
      public Parent() {
        ...
      }
    }
    
    public class Child : Parent {
      public Child() : base() { // calls Parent.ctor
      }
    }
