    TResult ExceptionalMethod<T, TResult>(Func<T, TResult> Methodx){
       try
       {
          return Methodx(T);
       }
       catch(ExceptionType1)
       {
       }
       catch(ExceptionType2)
       {
       }
       catch(ExceptionType3)
       {
     }}
