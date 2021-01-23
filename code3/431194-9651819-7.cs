         Public void Coke_ClickHandler (object sender, EventArgs args){
              PurchaseDrink("Coke", CokeCost);
         }
         // now we have a method that stands out and says THIS is how it works
         // and a single point of change, rather than ump-teen button handlers.
          private PurchaseDrink (string whatKind, double cost) {
             // all I did so far is move the code and change "Cokecost" to "cost"
             // Now I'm beginning to think I may need to pass "whatKind" to
             // DispenseDrink() - but first I need to test the changes I've
             // made at this level.
             // ***** and since I already tested the code when I 1st wrote it,
             // this refactoring will be easier & quicker to test.. GET IT??!! ******
             if (MoneySlot.Value >= cost) {
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
  
