    Socket s;
    // ...
    // Poll the socket for reception with a 10 ms timeout.
    if (s.Poll(10000, SelectMode.SelectRead))
    {
        s.Receive(); // This call will not block
    }
    else
    {
        // Timed out
    }
