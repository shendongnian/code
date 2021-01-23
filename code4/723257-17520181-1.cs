      // First, add port into your delegate
      private delegate void SetTextDeleg(SerialPort port, string text);
      ...
      /* HELP START */
     
      void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
        Thread.Sleep(500);
        SerialPort sp = (SerialPort) sender; // <- Obtain the serial port
        string data = sp.ReadLine();
    
        // Pass the serial port into  si_DataReceived: SetTextDeleg(sp, ...
        this.BeginInvoke(new SetTextDeleg(sp, si_DataReceived), new object[] { data }); 
      }
    
      // "SerialPort sp" is added
      private void si_DataReceived(SerialPort sp, string data) {
        String retorno = data.Trim();
        MessageBox.Show(retorno);
        // Fecha a porta após pegar o retorno
        sp.Close();
      }
    
      /* HELP END */
