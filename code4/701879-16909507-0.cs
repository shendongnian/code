       private void textBoxLeft_KeyDown(object sender, KeyEventArgs e)
       {
         if (e.KeyCode.Equals(Keys.Right))
         {
           e.Handled = true;
           //SendKeys.Send("{TAB}");
           textBoxRight.Focus();
         }
       }
       private void textBoxRight_KeyDown(object sender, KeyEventArgs e)
       {
        if (e.KeyCode.Equals(Keys.Left))
        {
          e.Handled = true;
         //SendKeys.Send("+{TAB}");
         textBoxLeft.Focus();
        }
     }
