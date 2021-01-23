       public class CokeMachine {
         Button Coke;
         Button 7Up;
         Button RootBeer;
         TextBox MoneySlot;
         double CokeCost = .75;
         double 7UpCost = .65;
         // "wiring up" the coke button click event to it's handler.
         // We do this in C# by declaring an new EventHandler object (a .NET framework supplied class)
         // and we pass in the name of our method as a parameter.
         // This new EventHandler is *added* to the button's click event.
         // An event can have multiple handlers, that's why we do "+="
         // instead of just "=". Otherwise we would have accidentally "unhooked" any
         // previously registered handlers.
         Coke.Click += new EventHandler(Coke_ClickHandler);
         // this is the .NET event handler method signature.
         Public void Coke_ClickHandler (object sender, EventArgs args){
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
         
      }
