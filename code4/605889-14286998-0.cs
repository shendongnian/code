    public class ActionType : IActionType
    {
       public static readonly ActionType UserLogin;
       public static readonly ActionType PurchaseOrder;
    
       static ActionType
       {
           UserLogin = new ActionType(1, "User Login");
           // ...
       }
       public class ActionType(int value, string name)
       {           
           // verify arguments values
           Value = value;
           Name = name;
       }
    
       public int Value { get; set; }
       public string Name { get; set; }
    }
