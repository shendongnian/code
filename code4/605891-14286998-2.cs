    public class ActionType : IActionType
    {
       public static readonly ActionType UserLogin;
       public static readonly ActionType PurchaseOrder;
    
       static ActionType()
       {
           UserLogin = new ActionType(1, "User Login");
           // ...
       }
       public ActionType(int value, string name)
       {           
           // verify arguments values
           Value = value;
           Name = name;
       }
    
       public int Value { get; private set; }
       public string Name { get; private set; }
    }
