    private void GetCurrentPivotItem(object sender, RoutedEventArgs e)
    {
        PivotItem pivotItem = (PivotItem)SomePivot.SelectedItem;
        Debug.WriteLine("Pivot Item : {0}", pivotItem.Header);
        foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(new Rect(20, 0, 480, 700), pivotItem))
        {
            if (element is Button)
            {
                Debug.WriteLine("{0}", ((Button)element).Content);
            }
        }
    }
