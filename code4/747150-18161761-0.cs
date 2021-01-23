    void Something()
    {
        MyColoredObject o = //something
        var textValues = new[] {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight"};
    
        foreach (MenuItem color in colors.MenuItems)
        {
            for (int i = 1; i <= 8; i++)
            {
                MenuItem newItem = new MenuItem();
                newItem.Text = textValues[i];
                newItem.Click += NumberClickHandler(o, color, i);
                color.MenuItems.Add(newItem);
            }
        }
    }
    EventHandler NumberClickHandler(MyColoredObject o, MenuItem color, int num)
    {
        return (s, e) =>
        {
            // assign the color to o as identified by color and num
        };
    }
