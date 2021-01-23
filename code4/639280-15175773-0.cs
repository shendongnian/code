    // We assume this will always be called from a non-UI thread...
    private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        bufferSerial += serialPort1.ReadLine();
        Action<string> d = SetAllTextBoxes;
        Invoke(d, bufferSerial);
    }
    private void SetAllTextBoxes(string text)
    {
        textBox1.Text = text;
        textBox2.Text = text;
        textBox3.Text = text;
        textBox4.Text = text;
        ...
    }
