    private delegate void UpdateUiTextDelegate(string text);
    private void Receive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        if (mySerialPort.IsOpen)
        {
            RxString = mySerialPort.ReadLine();
            Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(DisplayText), RxString);
        }
    }
    private void DisplayText(string RxString)
    {
        ...
    }
