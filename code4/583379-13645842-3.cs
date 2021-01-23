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
             case One:
               ... break;
             case Two:
               ... break;
             default:
               throw new UnaccountedForEnumException(
                    "uh oh - something went wrong", //<- exception message
                    new Exception("inner exception here")  //<-innerException
               );  
          }
        }
