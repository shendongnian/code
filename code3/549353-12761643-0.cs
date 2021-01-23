    private void portdatareceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
       string line = port.ReadExisting();
    
       SomeMethod(line);
    }
