    using(var hook = new KeyboardHookListener(new GlobalHooker()))
    {
        hook.Enabled = true;
        var keyDownSeq = Observable.FromEventPattern<KeyEventArgs>(hook, "KeyDown");
        var keyUpSeq = Observable.FromEventPattern<KeyEventArgs>(hook, "KeyUp");    
        
        var ctrlPlus =
            // Start with a key press...
            from keyDown in keyDownSeq
            // and that key is the lctrl key...
            where keyDown.EventArgs.KeyCode == Keys.LControlKey
            from otherKeyDown in keyDownSeq
                // sample until we get a keyup of lctrl...
                .TakeUntil(keyUpSeq
                    .Where(e => e.EventArgs.KeyCode == Keys.LControlKey))
                // but ignore the fact we're pressing lctrl down
                .Where(e => e.EventArgs.KeyCode != Keys.LControlKey)
            select otherKeyDown;
        using(var sub = ctrlPlus
               .Subscribe(e => Console.WriteLine("CTRL+" + e.EventArgs.KeyCode)))
        {
            Console.ReadLine();
        }
    }
