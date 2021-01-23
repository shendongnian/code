            StackPanel sp = new StackPanel();
            for (int i = 0; i < 5; i++)
            {
                UserControl uc = new UserControl();
                uc.Name = "name"+i; // add your name here
                sp.Children.Add(uc);
            }
