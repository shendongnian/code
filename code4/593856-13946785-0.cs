    class Child {
      public bool IsBeaten { get; private set; }
    
      public void Beat(Father beater) {
        IsBeaten = true;
      }
    }
    
    class Father {
      public void BeatChild(Child child) {
        child.Beat(this);
      }
    }
