    [assembly:  
    Log(AttributeTargetTypes="Contoso.Crm.Orders.*", 
        AttributeTargetMemberAttributes = MulticastAttributes.Public)]  
      
    public class OrderFulfillmentService  
    { 
        public bool IsValid( Order order )  
        { 
            if ( order.Lines.Count == 0 ) 
              return false; 
                     
            if ( order.Amount < 0 ) 
              return false; 
                         
            return true; 
             
        } 
    } 
