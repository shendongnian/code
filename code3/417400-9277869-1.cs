    TResult ExceptionalMethod<T, TResult>(Func<T, TResult> methodx, T parameter){
       try
       {
          return methodx(parameter);
       }
       catch(ExceptionType1)
       {
       }
       catch(ExceptionType2)
       {
       }
       catch(ExceptionType3)
       {
       }
       return default(TResult);
    }
