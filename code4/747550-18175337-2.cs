    [HandleProcessCorruptedStateExceptions]
    private static void Transmit(PacketCommunicator outputCommunicator, PacketSendBuffer sendBuffer, bool isSync)
        {
            try
            {
                outputCommunicator.Transmit(sendBuffer, isSync);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
