    public class Magic{
    
    private static Magic magic = new Magic();
    public static Magic Instance{
      get
        {
       magic.BaseMethod();
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
