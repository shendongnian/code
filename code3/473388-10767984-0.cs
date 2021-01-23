    var owner = Application.OpenForms["Form1"];
    form2.Load += delegate {
        // NOTE: just as a workaround for the Owner bug!!
        Control.CheckForIllegalCrossThreadCalls = false;
        form2.Owner = owner;
        Control.CheckForIllegalCrossThreadCalls = true;
        owner.BeginInvoke(new Action(() => owner.Enabled = false));
    
    };
    form2.FormClosing += new FormClosingEventHandler((s, ea) => {
        if (!ea.Cancel) {
            owner.Invoke(new Action(() => owner.Enabled = true));
            form2.Owner = null;
        }
    });
    form2.ShowDialog();
