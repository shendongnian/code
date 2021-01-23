    private void btnGeneral_Click(object sender, RoutedEventArgs e)
    {
        App.Current.Properties["TextBoxString"] = textBox1.Text;
        PanelMainContent.Children.Clear();
        Button button = (Button)e.OriginalSource;
        Type type = this.GetType();
        Assembly assembly = type.Assembly;
        MyControl myControl = _userControls[button.Tag.ToString()];
        myControl.TextBlockString = textBox1.Text;
        PanelMainContent.Children.Add(myControl);
    }
