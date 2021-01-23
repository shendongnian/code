    for (int i = 0; i<GridViewTickers.Items.Count; i++)
    {
        var element = GridViewTickers.ItemContainerGenerator.ContainerFromIndex(i) as FrameworkElement;
        if (element != null)
        {
            var tb = element.FindDescendantByName("Canv") as Canvas;
            if (tb != null)
            {
                TextBlock tb1 = new TextBlock();
                tb1.Text = "hello";
                tb.Children.Add(tb1);
            }
        }
    }
