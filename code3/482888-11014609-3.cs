    do
    {
        try
        {
            socket.Receive(reply, 0, 1, SocketFlags.None);
            replyString.Append(Encoding.ASCII.GetString(reply, 0, reply.Length));
            // Termination string logic...
        }
        catch (SocketException e)
        {
            // Check on e.SocketErrorCode if necessary.
            break;
        }
    
    } while (!terminationReached);
