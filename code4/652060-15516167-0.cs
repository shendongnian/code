        <ListBox x:Name="lstEmployee" SelectionChanged="lstEmployee_SelectionChanged_1" /> <br/><br/>
    
        private void lstEmployee_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            NewsItem selectedItem = (sender as ListBox).SelectedItem;
            if (selectedItem != null)
            {
                //Extra code here
            }
        }
