     //Generic argument remove from method declaration
     //because it was shadowing the type argument
     public ClientResult<T> ToClientResult()
     {
        var clientResult = ((Result)this).ToClientResult()
        var genericResult = (ClientResult<T>)clientResult;
        //do what you need to do with the generically typed object
        //...
        return genericResult
     }
