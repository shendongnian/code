    private void fiImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (tbN != null)
        {
            int i = ((FlipView)sender).SelectedIndex;
            tbN.Text = a[i]; 
        }
    }
