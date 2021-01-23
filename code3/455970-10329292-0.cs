    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Window1 w1 = new Window1();
        Window2 w2 = new Window2();
        Screen s1 = Screen.AllScreens[0];
        Screen s2 = Screen.AllScreens[1];
        Rectangle r1 = s1.WorkingArea;
        Rectangle r2 = s2.WorkingArea;
        w1.Top = r1.Top;
        w1.Left = r1.Left;
        w2.Top = r2.Top;
        w2.Left = r2.Left;
        w1.Show();
        w2.Show();
        w2.Owner = w1;
    }
