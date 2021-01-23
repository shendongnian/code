    var client = new TcpClient();
    client.Connect(endpoint);
    
    var stream = client.GetStream();
    var msgData = System.Text.Encoding.UTF8.GetBytes("msg\r\n"); //Include line ending. Might just need \r or \n by themselves - consult server documentation, if available
    stream.Write(msgData, 0, msgData.Length);
    
    var answerData = new Byte[256];
    var asnwerLength = stream.Read(answerData, 0, answerData.Length);
