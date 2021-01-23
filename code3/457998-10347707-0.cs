    var move = listBox.ItemsSource
                      .GetType()
                      .GetMethod("Move");
    if (move != null)
    {
        move.Invoke(listBox.ItemsSource, new[] { old, new });
    }
    else
    {
        // IList fallback?
    }
