    public class YourMVVM
    {
       public IPersonProperties BindToMe{ get; set }
    
       public YourMVVM()
       {
          BindToMe = new Man();
          // OR... BindToMe = new Woman();
       }
    }
