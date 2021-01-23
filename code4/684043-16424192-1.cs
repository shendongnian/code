    void Main()
    {
        var buttonObs = new ButtonObserver();
        var buttons = buttonObs.PollMouse(100).Where(mb => mb.LeftButton);
        using(buttons.Subscribe(mb => Console.WriteLine("Left button down")))
        {
            Console.ReadLine();
        }
        buttonObs.Dispose();
    }
