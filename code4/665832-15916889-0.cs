    private void txtICode_LostFocus(object sender, RoutedEventArgs e)
    {        
        if (!NewData)
            return;
        
        if (String.IsNullOrEmpty(txtICode.Text))
            return;
            
        Item temp = new Item();
        Item[] list = temp.Query(new object[] { Item.DataEnum.Item_Code }, new string[] { txtICode.Text });
        if (list.Length > 0)
        {
            System.Windows.Forms.MessageBox.Show("This item code is already being used.", "Invalid information");
        }
     }
