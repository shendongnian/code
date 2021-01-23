    EventHandler SetConfigInterfaceEnabledDelegate(string s, bool b)
    {
        return (o, e) => SetConfigInterfaceEnabled(s, b);
    }
    ConfigFileWritten += SetConfigInterfaceEnabledDelegate("", true);
