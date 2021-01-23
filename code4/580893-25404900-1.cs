    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (PivotItem pivotItem in MyPivot.Items)
        {
            if (pivotItem == MyPivot.Items[MyPivot.SelectedIndex])
            {
                // Header of the selected item to white
                ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            }
            else
            {
                // Headers of other items to slightly darker
                ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 230, 230, 230));
            }
        }
    }
