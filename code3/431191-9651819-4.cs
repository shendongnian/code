         Public void Coke_ClickHandler (object sender, EventArgs args){
              PurchaseDrink("Coke", CokeCost);
         }
         // now we have a method that stands out and says THIS is how it works
         // and a single point of change, rather than ump-teen button handlers.
          private PurchaseDrink () {
             if (MoneySlot.Value >= CokeCost) {
                 DispenseDrink();
                 // How do I handle returning change? Maybe DispenseDrink() can do that.
              }else {
                 // tell customer to put in more money
              }
         }
         private void DispenseDrink() {
           // An empty method is enough to get it to compile so for now that's fine.
           // I need to test the Coke_EventHandler logic that I've written so far.
         }
  
