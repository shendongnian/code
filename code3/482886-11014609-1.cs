    do
    {
        try
        {
            if (stream.DataAvailable)
            {
                stream.Read(reply, 0, 1);
                replyString.Append(Encoding.ASCII.GetString(reply, 0, reply.Length));
                // Compare to termination string.
                // .........
                }
            }
        }
        catch (IOException e)
        {
            break;
        }
    
        timedout = sw.ElapsedMilliseconds > timeout;
    
    } while (!terminationStringReached && !timedout);
