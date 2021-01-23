    foreach (string portname in SerialPort.GetPortNames())
    {
        var sp = new SerialPort(portname, 4800, Parity.Odd, 8, StopBits.One);
        try
        {
            sp.Open();
            sp.Write("Your known command to device");
            Thread.Sleep(500);
            string received = sp.ReadLine();
            if (received == "expected response")
            {
                Console.WriteLine("device connected to: " + portname);
                break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("device NOT connected to: " + portname);
        }
        finally
        {
            sp.Close();
        }
    }
