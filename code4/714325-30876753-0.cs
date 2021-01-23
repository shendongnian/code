        try
        {
            socket = listeningSocket.Accept();
            Console.WriteLine("Connectd...");
            while (true)
            {
                try
                {
                    // Receiving
                    byte[] buffer = new byte[socket.SendBufferSize];
                    int iBufferLength = socket.Receive(buffer, 0, buffer.Length, 0);
                    Console.WriteLine("Received {0}", iBufferLength);
                    Array.Resize(ref buffer, iBufferLength);
                    string formattedBuffer = Encoding.ASCII.GetString(buffer);
                    Console.WriteLine("Android Says: {0}", formattedBuffer);
                    if (formattedBuffer == "quit")
                    {
                        socket.Close();
                        listeningSocket.Close();
                        Console.WriteLine("Exiting");
                        Environment.Exit(0);
                    }
                    //Console.WriteLine("Inside Try i = {0}", i.ToString());
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    //socket.Close();
                    Console.WriteLine("Receiving error: " + e.ToString());
                    Console.ReadKey();
                    //throw;
                }
            }
        }
        catch (Exception e)
        {
            //socket.Close();
            Console.WriteLine("Error After Loop: " + e.ToString());
        }
        finally
        {
            Console.WriteLine("Closing Socket");
            socket.Close();
            //listeningsocket.close();
        }
