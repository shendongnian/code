    public bool myMethod(ref IMyAbstractBaseClass anObject)
    {
          myObject = new MyFirstClass();
          return true;
    }
    public bool myMethod2(MyAbstractBaseClass anObject)
    {
          myObject.SomeProperty = 5;
          return true;
    }
    IMyAbstractBaseClass myObject = new MyFirstClass();
    result1 = myMethod(ref myObject);
    result1 = myMethod2(myObject);
   
