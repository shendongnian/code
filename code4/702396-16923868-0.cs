    Screen screen1 = new Screen();
    screen1.Length = 23;
    screen1.Width = 50;
    Screen screen2 = new Screen();
    screen2.Length = 23;
    screen2.Width = 50;
    List<Screen> screens = new List<Screen>();
    screens.Add(screen1);
    screens.Add(screen2);
    Debug.WriteLine(screen1.GetHashCode()); // in my test, this output '45653674'
    Debug.WriteLine(screens[0].GetHashCode()); // in my test, this output '45653674'
    Debug.WriteLine(screen2.GetHashCode()); // in my test, this output '45523402'
    Debug.WriteLine(screens[1].GetHashCode()); // in my test, this output '45523402'
