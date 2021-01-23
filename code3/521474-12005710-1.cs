        Using NativeWifi;
        Class MyAPP : Form
        {
        
          public void PrintRSSI()
          {
        
              WlanClient client = new WlanClient();
              var interfaces = client.Interfaces;
  
              //Now chose an interface out of all the available interfaces. Usually there would be zero or 1 interfaces available
              if(interfaces.Length > 0)
              {
                  //Select first available interface. A more complicated logic can present the list of available interfaces to the user and and then display RSSI for the selected interface
                  wifi.Text = interfaces[0].RSSI.ToString();
              }
           }
         //Other code for the class
        }
    
