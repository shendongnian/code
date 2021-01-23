    private void LayoutRoot_Tap(object sender, GestureEventArgs e)
    {
        if (e.OriginalSource == LayoutRoot)
            MessageBox.Show("You clicked on LayoutRoot!");
        else
            MessageBox.Show("You clicked on somewhere else!");
    }
