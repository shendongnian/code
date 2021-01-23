    Application.Init();
    MainWindow win = new MainWindow();
    win.KeyPressEvent += (sender, e) =>
    {
        win.MethodWithLogic(e.Event.Key);
    }; 
    Button btn1 = win.getButton1();
    btn1.Pressed += (sender, e) => 
    { 
        Console.WriteLine("Button1 pressed"); 
        win.MethodWithLogic(Gdk.Key.a);
    };
    win.Show(); 
    Application.Run(); 
