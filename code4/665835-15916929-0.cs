               private void txtICode_LostFocus(object sender, RoutedEventArgs e)
                {
                   string inputText = txtICode.Text;
                   if (string.IsNullOrEmpty(inputText) || !NewData)
                   {
                       return;
                   }
                   Item temp = new Item();
                   Item[] list = temp.Query(new object[] { Item.DataEnum.Item_Code }, 
                                                           new string[] { inputText  });
                   if (list != null && list.Length > 0)
                   {
                      MessageBox.Show("This item code is already being used.", "Invalidinformation");
                      txtICode.Focus();
                      return;
                    }
                }
