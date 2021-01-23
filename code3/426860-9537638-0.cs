    //this is a very rough model of how to do it. a lot more would need to be implemented
    //i'm assuming you plan to continuously read from it. i can think up another example if you're not
    //also not thread safe
    public class MyPipeClient
    {
        NamedPipeClientStream PipeClient = new NamedPipeClientStream("testpipe1");
        Timer TimeoutTimer;
        DateTime LastRead;
        const int TimeoutSeconds = 120; //2 mins
        //will connect and start receiving
        public void Connect()
        {
            PipeClient.Connect();
            LastRead = DateTime.Now;
            TimeoutTimer = new Timer(TimeoutCheck, this, 0, 1000); //check every second
            Read(this);
        }
        public void Disconnect()
        {
            PipeClient.Close(); PipeClient = null;
            TimeoutTimer.Dispose(); TimeoutTimer = null;
        }
        static void Read(MyPipeClient client)
        {
            PipeState state = new PipeState(client);
            try
            {
                client.PipeClient.BeginRead(state.Buffer, 0, state.Buffer.Length, ReadCallback, state);
            }
            catch (InvalidOperationException) //disconnected/disposed
            {
                return;
            }
        }
        static void ReadCallback(IAsyncResult ar)
        {
            PipeState state = (PipeState)ar.AsyncState;
            MyPipeClient client = state.Client;
            client.LastRead = DateTime.Now;
            int bytesRead;
            try
            {
                bytesRead = client.PipeClient.EndRead(ar);
            }
            catch (IOException) //closed
            {
                return;
            }
            if (bytesRead > 0)
            {
                byte[] data = state.Buffer;
                //TODO: something
            }
            else //i've never used pipes, so i'm assuming this behavior exists with them
            {
                client.Disconnect();
                return;
            }
            Read(client);
        }
        static void TimeoutCheck(object state)
        {
            MyPipeClient client = (MyPipeClient)state;
            TimeSpan timeSinceLastRead = DateTime.Now - client.LastRead;
            if (timeSinceLastRead.TotalSeconds > TimeoutSeconds)
            {
                client.Disconnect();
            }
        }
    }
    class PipeState
    {
        public byte[] Buffer = new byte[4096];
        public MyPipeClient Client;
        public PipeState(MyPipeClient client)
        {
            Client = client;
        }
    }
