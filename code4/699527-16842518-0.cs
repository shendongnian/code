    this.Cursor = Cursors.SizeNWSE;
    var sw1 = Stopwatch.StartNew();
    for (var i = 0; i < 10000000; i++)
    {
        this.Cursor = Cursors.SizeNWSE;
    }
    sw1.Stop();
    var sw2 = Stopwatch.StartNew();
    for (var i = 0; i < 10000000; i++)
    {
        if (this.Cursor != Cursors.SizeNWSE)
        {
            this.Cursor = Cursors.SizeNWSE;
        }
    }
    sw2.Stop();
