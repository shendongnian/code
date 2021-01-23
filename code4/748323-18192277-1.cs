    if (Reader.Name == "BaudRate")
    {
        Reader.Read();
        Int32 BaudRate;
        if (Int32.TryParse(Reader.Value, out BaudRate))
        {
            BaudRatebx.SelectedItem = BaudRate.ToString();
            MainBoxWindow.ApplicationPort.BaudRate = BaudRate;
        }
    }
