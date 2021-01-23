       private void tbPrinciple_TextChanged(object sender, EventArgs e)
       {
           // Use TryParse instead of Parse in case the user enters text or some
           // other non-numeric character
           double enteredPrinciple = 0;
           if (double.TryParse(tbPrincipal.Text, out enteredPrinciple))
           {
               if (enteredPrinciple < 0)
               {
                   // Console.WriteLine won't display anything to the user
                   MessageBox.Show("The value for the mortgage cannot be a negative value");
               }
               else
               {
                   // Assign it to the property
                   principle = enteredPrinciple;
               }
           }
           else
           {
               // Prompt the user to enter a numeric value
               MessageBox.Show("The value for the mortgage must be a numeric value");
           }
       } 
