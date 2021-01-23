    public class CartItem
    {
       public int ProductID {get;set;}
       public int Quantity {get;set;}
    }
    List<CartItem> items = new List<CartItem>();
    items.Add(new CartItem() { ProductID = 1, Quantity = 2 })
    
    Session["cartItems"] = items;
    
    to get it back again
    
    if(Session["cartItems"] != null)
       List<CartItem> items = (List<CartItem>)Session["cartItems"];
