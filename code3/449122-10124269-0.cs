    void OnCurrentTabChanged(int tabIndex)
    {
        if (dataDisplay != null)
        {
            UIElemnt[] pp = dataDisplay.Children.Cast<UIElement>().ToArray();
            Array.ForEach(pp, x=> x.visibility = Visibility.Collapsed); 
            pp[tabIndex].visibility = Visibility.Visible;
        }
    }
