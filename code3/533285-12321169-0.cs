    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Thread t = new Thread( YourMethod);
        t.IsBackground = true;
        t.Start();
    }
    void YourMethod()
    {
        consolemessage("STARTUP", "Verifying existence of essential files...");
        if (!File.Exists("Interop.NATUPNPLib.dll"))
            Download("link here", "Interop.NATUPNPLib.dll");
        if (!File.Exists("LICENSE.txt"))
            Download("link here", "LICENSE.txt");
        consolemessage("STARTUP", "Essential file validation completed!");
    }
