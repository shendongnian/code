    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading;
    public class SerialTest
    {
        public static void Main()
        {
            SerialPort serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM5"; // Set in Windows
            serialPort.Open();
            int counter = 0;
            while (serialPort.IsOpen)
            {
                // WRITE THE INCOMING BUFFER TO CONSOLE
                while (serialPort.BytesToRead > 0)
                {
                    Console.Write(Convert.ToChar(serialPort.ReadChar()));
                }
                // SEND
                serialPort.WriteLine("PC counter: " + (counter++));
                Thread.Sleep(500);
            }
        }
    }
