    public class myclass{
       public string arduinoData = "";
    
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.arduinoData = serialPort1.Read(data, 0, data.Length);
        } 
     //....The rest of your code such as main methods yada yada yada...
    
    }
