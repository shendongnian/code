    public static void AutoRowsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        RowDefinitionCollection rows = ((Grid)obj).RowDefinitions;
        rows.Clear();
    
        foreach (string segment in ((string)e.NewValue).Split(','))
        {
            if (segment.StartsWith("~"))
            {
                int count;
                if (!int.TryParse(segment.Substring(1), out count))
                    count = 1;
    
                for (int i = 0; i < count; i++)
                    rows.Add(new RowDefinition() { Height = GridLength.Auto });
            }
            else
            {
                GridLengthConverter converter = new GridLengthConverter();
                rows.Add(new RowDefinition() { Height = (GridLength)converter.ConvertFromString(segment) });
            }
        }
    }
