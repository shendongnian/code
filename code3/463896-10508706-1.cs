    private void releaseHoldDropDown_SelectionChanged(object sender, FooBar e)
    {
       releaseHoldDropDown.ForeGround = new SolidColorBrush(Colors.White);
       DataSource ds = (DataSource)releaseHoldDropDown.SelectedItem;
       if (ds.DisplayField == "Release")
            releaseHoldDropDown.Background = new SolidColorBrush(Colors.Green);
       else if(ds.DisplayField == "Hold")
            releaseHoldDropDown.Background = new SolidColorBrush(Colors.Red);
    }
