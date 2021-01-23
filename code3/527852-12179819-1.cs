    private static void MinChangedCallback(DependencyObject o, TheRightKindOfArgs e)
    {
        var control = (MyCustomControl)o;
        control.UpdateRange((DateTime)e.NewValue, Maximum);
    }
    private static void MaxChangedCallback(DependencyObject o, TheRightKindOfArgs e)
    {
        var control = (MyCustomControl)o;
        control.UpdateRange(Minimum, (DateTime)e.NewValue);
    }
    
    private void UpdateRange(DateTime min, DateTime max)
    {
        var range = new Range<DateTime>(min, max);
        SetCurrentValue(SearchRangeProperty, range);
    }
