        using (var sp = new System.IO.Ports.SerialPort("COM11", 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
        {
            sp.Open();
            sp.WriteLine("Hello!");
            var readData = sp.ReadLine();
            Console.WriteLine(readData);
        }
