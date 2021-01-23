    enum SomeEnum
    {
      One,
      Two
    }
    void someFunc()
    {
      SomeEnum value = someOtherFunc();
      switch(value)
      {
       case SomeEnum.One:
        ... break;
       case SomeEnum.Two:
        ... break;
       default:
          throw new UnexpectedEnumValueException<SomeEnum>(value);    
      }
    }
