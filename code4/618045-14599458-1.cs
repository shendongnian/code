    private void Accepted(IAsyncResult result)
    {
        Socket sck = result.AsyncState as Socket;
        Socket client = sck.EndAccept(result);
        sck.BeginAccept(Accepted, sck);
    }
            Socket accepted = sck.Accept();
 
