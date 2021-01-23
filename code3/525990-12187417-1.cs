    private void T1_KeyDown_1(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
            T2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
    }
    private void T2_KeyDown_1(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
            T1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
    }
