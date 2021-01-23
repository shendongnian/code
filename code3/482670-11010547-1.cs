    class Robot
    {
         public Item CurrentItem { get; private set; }
 
         public void PickUpItem(Item i)
         {
             CurrentItem = i;
         }
         public void UseItem()
         {
             CurrentItem.Use(); // will call Use generically on whatever item you're holding
         }         
    }
...
    Robot r = new Robot();
    r.PickUpItem(new Knife());
    r.UseItem(); // uses knife
    r.PickUpItem(new Hammer());
    r.UseItem(); // uses hammer
