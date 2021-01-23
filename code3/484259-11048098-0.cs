    public Window GetFocusWindow()
    {
        Window results = null;
        for (int i = 0; i < Application.Current.Windows.Count; i ++)
            if (Application.Current.Windows[i].IsFocused)
            {
                results = Application.Current.Windows[i];
                break;
            }
        return results;
    }
