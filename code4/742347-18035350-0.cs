     private void ResetTextBoxes(Control cntrl)
     {
         foreach(Control c in cntrl)
         {
              ResetTextBoxes(c);
              if(c is TextBox)
                (c as TextBox).Text = string.Empty;
         }
     }
