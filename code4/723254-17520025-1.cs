    foreach (var port in portNames)
    {
        // Object initializer to simplify setting properties
        SerialPort sp = new SerialPort(port, 19200, Parity.None, 8, StopBits.One)
        {
            Handshake = Hanshake.None,
            ReadTimeout = 500,
            WriteTimeout = 500
        };
        sp.DataReceived += (sender, args) =>
        {
            Thread.Sleep(500); // Not sure you need this...
            string data = sp.ReadLine();
            Action action = () => {
                MessageBox.Show(data.Trim());
                sp.Close();
            };
            BeginInvoke(action);
        };
        serialPort.Add(sp);
        listPorts.Items.Add(port);
    }
