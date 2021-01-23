    private void makeVisible(int x)
    {
        var boxes = new TextBox[] { field2, field3... };
        foreach (TextBox box in boxes)
        {
            box.Visibility = (x == 1) ? Visibility.Visible : Visibility.Collapsed;
        }
        if (x == 0)
        {
            errorReporter.Visibility = Visibility.Collapsed;
        }
    }
