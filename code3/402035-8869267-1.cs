    using (NetworkStream serverStream = client.GetStream())
    using (StreamWriter writer = new StreamWriter(serverStream))
    {
        do
        {
            Console.Write(" >> Info to send: ");
            infoToSend = Console.ReadLine();
            if (!String.IsNullOrEmpty(infoToSend))
                writer.WriteLine(infoToSend);
        } while (!String.IsNullOrEmpty(infoToSend));
    }
