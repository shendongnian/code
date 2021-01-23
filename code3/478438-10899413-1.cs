    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        ReadData = port.ReadExisting();
        //Add code to split up/decode the incoming data
        if (lblCallerIDTitle.InvokeRequired)
            lblCallerIDTitle.Invoke(() => lblCallerIDTitle.Text = ReadData);
        else
            lblCallerIDTitle.Text = ReadData;
        Console.WriteLine(ReadData);
    }
