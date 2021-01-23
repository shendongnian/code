    public static void AcceptConnection(IAsyncResult ar)
    {
        // Get the socket that handles the client request.
        Socket listener = (Socket)ar.AsyncState;
        // start another listening operation
        listener.BeginAccept(new AsyncCallback(AcceptConnection), listener);
        ... the rest of the method
    }
