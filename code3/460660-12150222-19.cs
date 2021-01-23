    using System;
    using System.IO.Ports;
    
    class fooForm and normal stuff
    {
        SerialPort port;
    
        private myFormClose()
        {
            if (port != null)
            port.close();
        }
        private myFormOpen()
        {
            port = new SerialPort("COM4", 57600);
            try
            {
                //un-comment this line to cause the arduino to re-boot when the serial connects
                //port.DtrEnabled = true;
    
                port.Open();
            } 
            catch (Exception ex)
            {
                //alert the user that we could not connect to the serial port
            }
        }
    
        private void myCheckboxClicked()
        {
            if (myCheckbox.checked)
            {
                port.Write("a");
            } 
            else
            {  
                port.Write("b");    
            }
        }
    }
