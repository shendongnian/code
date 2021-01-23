        using System;
        using System.IO.Ports;
        using System.Collections;
        using System.Collections.Generic;
        using System.Text;
         
        
        private static bool IsModem(string PortName)
        {
          
          SerialPort port= null;
           try
           { 
             port = new SerialPort(PortName,9600); //9600 baud is supported by most modems
             port.ReadTimeout = 200;
             port.Open();
             port.Write("AT\r\n");
             
             //some modems will return "OK\r\n"
             //some modems will return "\r\nOK\r\n"
             //some will echo the AT first
             //so
             for(int i=0;i<4;i++) //read a maximum of 4 lines in case some other device is posting garbage
             {
                  string line = port.ReadLine();
                  if(line.IndexOf("OK")!=-1)
                  {
                     return true;
                  }
             }
            return false;
                  
         
           }
           catch(Exception ex)
           {
             // You should implement more specific catch blocks so that you would know 
             // what the problem was, ie port may be in use when you are trying
             // to test it so you should let the user know that as he can correct that fault
    
              return false;
           }
           finally
           {
             if(port!=null)
             {
                port.Close();
             }     
           }
         
           
           
        }
         
        public static string[] FindModems()
        {
          List<string> modems = new List<string>();
          string[] ports = SerialPort.GetPortNames();
         
           for(int i =0;i<ports.Length;i++)
           {
             if(IsModem(ports[i]))
             {
               modems.Add(ports[i]);
             }
            }
            return modems.ToArray();
        }
