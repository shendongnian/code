    private void TextBox_KeyDown_Number(object sender, KeyRoutedEventArgs e)
    {
        if ((uint)e.Key >= (uint)Windows.System.VirtualKey.Number0 
            && (uint)e.Key <= (uint)Windows.System.VirtualKey.Number9)
        {
            e.Handled = false;
        }
        else e.Handled = true;       
    }
