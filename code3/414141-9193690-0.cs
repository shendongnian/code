    public class Magic{
    
    private static Magic magic;
    public static Magic Instance{
      get
        {
       BaseMethod();
        return magic;
        }
    }
    
    public void BaseMethod(){
    }
    
    //runs BaseMethod before being executed
    public void Method1(){
    }
    
    //runs BaseMethod before being executed
    public void Method2(){
    }
    }
