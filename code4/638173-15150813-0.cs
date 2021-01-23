    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string sdsd = serialPort1.ReadLine();
        string Hexed = new LasalleRFIDComputerRentals.BLL.DAL.Utils().HexIt(sdsd);
        SetRFIDText(Hexed);
        btnOK_click(sender, e);
    }
