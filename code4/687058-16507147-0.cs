    private void MyTextBox_TextChanged(object sender, EventArgs e)
    {
       try
       {
          if(String.IsNullOrEmpty(((TextBox)sender).Text)))
          {
              MyClearButton.Enabled = false;
          }
          else
          {
              MyClearButton.Enabled = true;
          }
       }
       catch
       {
           MyClearButton.Enabled = false;
       }
    }
