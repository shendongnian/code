        interface IGroceryItem
        { 
           CheckoutIssues EnsureFreshness(); //I am skeptic about having this method on GroceryItem
        }   
    
        class GroceryCart:IGroceryCart
        {
           public void AddItem(IEnumerable<IGroceryItem> itemsToBuy)
           {
        
           }
        }
    
        class Billing
       {
        
    
        public decimal BillItems(GroceryCart cart)
        {
             foreach item in cart
               if(itemIsfresh)
                 Bill it.
        } 
     
       
    
         private bool IsItemFresh(GroceryItem item)
         {
        
         }
    
      }
