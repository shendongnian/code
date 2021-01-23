    var context = InvokeContext.CreateContext;
    var type = target.GetType()
    while(true){
       try{
          Console.WriteLine(Impromptu.InvokeMember(context(target, type), "Method", 2));  
          break;
       }catch(RuntimeBinderException ex){
           type = type.BaseType;
           if(type ==null)
              throw ex;
       }
    }
