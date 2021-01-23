    do
    {
        try
        {
            if (socket.Poll(socketTimeout, SelectMode.SelectRead))
            {
                socket.Receive(reply, 0, 1, SocketFlags.None);
            }
            else
            {
                throw new SocketException((int)SocketError.TimedOut);
            }
            replyString.Append(Encoding.ASCII.GetString(reply, 0, reply.Length));
            // Termination string logic...
        }
        catch (SocketException e)
        {
            // Check on e.SocketErrorCode if necessary.
            break;
        }
    
    } while (!terminationReached);
