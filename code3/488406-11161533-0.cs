    List<Button> toRemove = new List<Button>();
    foreach (var o in canvas1.Children)
    {
        if (o is Button)
            toRemove.Add((Button)o);
    }
    for (int i = 0; i < toRemove.Count; i++)
    {
        canvas1.Children.Remove(toRemove[i]);
    }
