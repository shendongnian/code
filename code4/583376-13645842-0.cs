        enum SomeEnum
        {
          One,
          Two,
          Three //<- unknown
        }
        void someFunc()
        {
          SomeEnum value = someOtherFunc();
          switch(value)
          {
             case One:
               ... break;
             case Two:
               ... break;
             default:
               ...  SomeEnum.Three;  
          }
        }
