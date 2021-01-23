    for(var i = 0; i < 4; i++)
    {
        var t = new Thread((s) =>
            {
                Application.Run(
                    new Form
                    {
                        Text = s.ToString()
                    });
            });
        
        t.IsBackground = true;
        t.SetApartmentState(ApartmentState.STA);
        t.Start(i);
    }
