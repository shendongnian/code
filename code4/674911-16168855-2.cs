     protected override void OnKeyPress(KeyPressEventArgs e)
     {
         //newChar will be passed to the base
         char newChar = e.KeyChar;
         
         if (e.KeyChar == 'a')
         {
             //handle the event and cancel the original key 
             e.Handled = true;
 
            //get caret position
             int tbPos = this.SelectionStart;
             //insert the new text at the caret position
             this.Text = this.Text.Insert(tbPos, "b");
             //update the newChar
             newChar = 'b';       
 
             //replace the caret back to where it should be 
             //otherwise the insertion call above will reset the position
             this.Select(tbPos + 1, 0);
         }
         base.OnKeyPress(new KeyPressEventArgs(newChar));
    }
