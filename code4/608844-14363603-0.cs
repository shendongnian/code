     private void UIObject_KeyDown(object sender, KeyEventArgs e)
     {
          if (e.KeyCode == Keys.Enter)
          {
               OtherUIObject_DoubleClick(sender, e); 
               // You can replace "sender" with "this", and/or replace "e" with a new EventArgs.
          }
     }
     private void OtherUIObject_DoubleClick(object sender, EventArgs e)
     {
        // Code
     }
