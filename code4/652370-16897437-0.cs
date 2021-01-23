Try using code below
    try
    {
       if (e.RemovedItems != null && e.RemovedItems.Count > 0)
       {
                        if (this.mode.SelectedItem != null)
                        {
                            var selectedItem = (sender as ListPicker).SelectedItem as ListPickerItem;
                            int selindex = mode.SelectedIndex; //just for testing
                            MessageBox.Show(selindex.ToString()); //just for testing
                            string text = (selectedItem as ListPickerItem).Content.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
