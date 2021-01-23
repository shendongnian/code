      ChildControl control = ...
      control.Removed += new EventHandler(ChildRemoved);
     
      // This will be called whenever the Child Removed:
      private void ChildRemoved(object sender, EventArgs e) 
      {
         ChildControl childControlThatRemoved = (ChildControl) sender;
         Console.WriteLine("This is called when the Child Removed.");
      }
