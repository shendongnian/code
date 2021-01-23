    foreach (var menu in menuBuilder)
    {
        if (menu.Visible)
        {
            foreach (Button item in menuButtons)
            {
                if ((int)item.Tag == menu.Tag)
                    item.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
