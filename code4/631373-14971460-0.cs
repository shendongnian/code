    public class MyController :Controller{
       OldController old;
       public MyController(){
          old=new OldController();
       }
    
       public ActionResult Product(int productid){
       }
    
       //Other OldController Method
       public ActionResult Method1(...){
          return old.Method1(...);
       }
    }
