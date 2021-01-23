    protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e) {
        //...
        switch (command.ToLowerInvariant()) {
            // etc..
            default:
                base.OnStartupNextInstance(e);   // Brings it to the front
                System.Windows.Forms.MessageBox.Show("Argument not supported");
                break;
        }
    }
