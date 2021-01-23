    // generate this stub by double clicking the ok/submit button in the GUI builder
    private void FirstName_EnterButtonClicked(object sender, EventArgs e)
    {
          char[] chars = FirstNameTextBox.Text.ToCharArray();
          bool good = true;
          int placeholder;
          
          for (int i = 0; i < chars.length; i++)
          {
               if (int.TryParse(chars[i], placeholder)
               {
                    good = false;
                    break;
               }
          }
          if (!good)
             MessageBox.Show("Names cannot contain numbers."); 
    }
