    StringBuilder page = new StringBuilder();
    do
    {
        bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
        if (bytes == -1)
        {
             // Error in socket, quit
             s.Close();
             return;
        }
        else if (bytes > 0)
             page.Append(Encoding.GetEncoding("UTF-8").GetString(bytesReceived, 0, bytes));
    }
    while (bytes > 0);
