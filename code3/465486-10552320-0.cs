    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case 537: //WM_DEVICECHANGE
                var ports = SerialPort.GetPortNames().OrderBy(name => name);
                foreach (var portName in ports)
                {
                    Debug.Print(portName);
                }
                break;
        }
        base.WndProc(ref m);
    }
