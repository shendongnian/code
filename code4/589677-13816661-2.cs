    public class MyClass {
      private object _property;
      public object Property {
        get { return _property; } //<-- _property reference copied on to stack & returned
                                  //    here as a new variable.  Therefore a ref
                                  //    on that is effectively meaningless.
                                  //    for a ref to be possible you'd need a pointer 
                                  //    to the _property variable (in C++ terms)
        set { _property = value; }
      }
    }
