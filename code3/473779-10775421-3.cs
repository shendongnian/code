    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      txt += serialPort1.ReadExisting().ToString();
      SetText(txt.ToString());
    }
