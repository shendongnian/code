    private void Form1_Load(object sender, EventArgs e)
    {
        // Create the ElementHost control for hosting the
        // WPF UserControl.
        ElementHost host = new ElementHost();
        host.Dock = DockStyle.Fill;
    
        // Create the WPF UserControl.
        HostingWpfUserControlInWf.UserControl1 uc =
            new HostingWpfUserControlInWf.UserControl1();
    
        // Assign the WPF UserControl to the ElementHost control's
        // Child property.
        host.Child = uc;
    
        // Add the ElementHost control to the form's
        // collection of child controls.
        this.Controls.Add(host);
    }
