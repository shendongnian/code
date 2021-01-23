        if (sender is UserControl)
        {
            UserControl u = sender as UserControl();
            Control buttonControl = u.Controls["The Button Name"];
            Button button = buttonControl as Button;
        }
