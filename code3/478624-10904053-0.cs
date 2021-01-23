    abstract class Parent
    {
       public virtual void DoWork(...common arguments...)
       {
          // ...common flow
          this.CustomWork();
          // ...more common flow
       }
    
       // the Customwork method must be overridden
       protected abstract void CustomWork();
    }
