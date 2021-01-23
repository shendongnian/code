    bool clicked = false;
    trackBar1.Scroll += (s,
                            e) =>
    {
        if (clicked)
            return;
        Console.WriteLine(trackBar1.Value);
    };
    trackBar1.MouseDown += (s,
                            e) =>
    {
        clicked = true;
    };
    trackBar1.MouseUp += (s,
                            e) =>
    {
        if (!clicked)
            return;
        clicked = false;
        Console.WriteLine(trackBar1.Value);
    };
