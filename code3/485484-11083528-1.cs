        private void chkbox_chkall_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chkbox_chkall = sender as CheckBox;
            foreach (OnlineActivatedProducts rowItem in (grdProducts.ItemsSource))
            {
                CheckBox chk = grdProducts.Columns[6].GetCellContent(rowItem) as CheckBox;
                if (chkbox_chkall.IsChecked == true)
                {
                    chk.IsChecked = true;
                }
                else
                {
                    chk.IsChecked = false;
                }
                chkBoxRow_Click(chk, e); // which bubbles each rows checked / unchecked event
            }
        } 
        private void chkBoxRow_Click(object sender, RoutedEventArgs e)
        {
            if (chkBoxContent.IsChecked.Value)
            {
                //if checked do something here 
            }
            else if (!chkBoxContent.IsChecked.Value)
            {
                //if unchecked do something here
            }
        }
     
     
