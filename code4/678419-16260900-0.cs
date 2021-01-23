    private void txtrate_TextChanged(object sender, EventArgs e) 
    { 
          int number;
          bool result = Int32.TryParse(txtqty.Text, out number);
          if (result)
          {
             //Converting is Ok, proceed        
          }
          else
          {
             //Convertign fail
             MessageBox.Show("Please enter only number for this field");
          }
       }
