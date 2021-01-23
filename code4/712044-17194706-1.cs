    public partial class SingleDictionaryValueSelector : IMyCustomInterface
    {
         ....
        private void cb_KeyDown(object sender, KeyEventArgs e)
        {
            RadComboBox senderCombo = sender as RadComboBox;
            ...
        }
        
        private void cb_KeyUp(object sender, KeyEventArgs e)
        {
            SearchExecute();
        }
     
        
        private void cb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RadComboBox senderCombo = sender as RadComboBox;
            ...  
        }
        private void cb_DropDownOpened(object sender, EventArgs e)
        {
           ...
        }
        ...
    }
