    bool flag = true; // just so we know we are still reading
    string headerString = ""; // to store header information
    int contentLength = 0; // the body length
    byte[] bodyBuff = new byte[0]; // to later hold the body content
    while (flag)
    {
	// read the header byte by byte, until \r\n\r\n
	byte[] buffer = new byte[1];
    socket.Receive(buffer, 0, 1, 0);
    headerString += Encoding.ASCII.GetString(buffer);
    if (headerString.Contains("\r\n\r\n"))
    {
		// header is received, parsing content length
		// I use regular expressions, but any other method you can think of is ok
        Regex reg = new Regex("\\\r\nContent-Length: (.*?)\\\r\n");
        Match m = reg.Match(headerString);
        contentLength = int.Parse(m.Groups[1].ToString());
        flag = false;
		// read the body
        bodyBuff = new byte[contentLength];
        socket.Receive(bodyBuff, 0, contentLength, 0);
    }
    }
    Console.WriteLine("Server Response :");
    string body = Encoding.ASCII.GetString(bodyBuff);
    Console.WriteLine(body);
    socket.Close();
