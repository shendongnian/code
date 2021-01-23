    Window win = new Window();
            StackPanel stack = new StackPanel { Orientation = Orientation.Vertical };
            stack.Children.Add(new CustomControl());
            stack.Children.Add(new CustomControl());
            stack.Children.Add(new CustomControl());
            stack.Children.Add(new CustomControl());
            win.Content = stack;
    win.ShowDialog();
