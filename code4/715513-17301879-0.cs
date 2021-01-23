    using System;
    using System.IO.Ports;
    using System.Threading;
    
    namespace Terminal_0._0._0._2
    {
        class Program
        {
            private static bool _continue;
            private static SerialPort _serialPort;
    
            public static void Main()
            {
                string name;
                string message;
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
                var readThread = new Thread(Read);
    
                // Create a new SerialPort object with default settings.
                _serialPort = new SerialPort
                    {
                        PortName = "COM8",
                        BaudRate = 115200,
                        Parity = Parity.None,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Handshake = Handshake.None,
                        ReadTimeout = 500,
                        WriteTimeout = 500
                    };
    
                // Allow the user to set the appropriate properties.
    
                // Set the read/write timeouts
    
                _serialPort.Open();
                _continue = true;
                readThread.Start();
    
                Console.Write("Name: ");
                name = Console.ReadLine();
    
                Console.WriteLine("Type QUIT to exit");
    
                while (_continue)
                {
                    message = Console.ReadLine();
    
                    if (stringComparer.Equals("quit", message))
                    {
                        _continue = false;
                    }
                    else
                    {
                        _serialPort.WriteLine(
                            String.Format("<{0}>: {1}", name, message));
                    }
                }
    
                readThread.Join();
                _serialPort.Close();
            }
    
            public static void Read()
            {
                while (_continue)
                {
                    try
                    {
                        string message = _serialPort.ReadLine();
                        Console.WriteLine(message);
                    }
                    catch (TimeoutException) { }
                }
            }
        }
    }
