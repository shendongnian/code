    IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint port = new IPEndPoint(address, 9999); //port 9999
            TcpListener listener = new TcpListener(port);
            listener.Start();
            Console.WriteLine("--Server loaded--");
            while (true) //loop forever
            {
                Console.WriteLine("Waiting for New Client");
                Socket sock = listener.AcceptSocket();
                byte[] buffer = new byte[32];
                string incomingMessage="";
                //read:
                while (sock.Available > 0)
                {
                    int gotBytes = sock.Receive(buffer);
                    incomingMessage += Encoding.ASCII.GetString(buffer, 0, gotBytes);
                }
                //debugging:
                //Console.WriteLine(incomingMessage);
                //Now check whether its a GET or a POST
                if (incomingMessage.ToUpper().Contains("POST") && incomingMessage.ToUpper().Contains("/DOSEARCH")) //a search has been asked for
                {
                    Console.WriteLine("Query Has Been Received");
                    
                    //extracting the post data
                    string htmlPostData = incomingMessage.Substring(incomingMessage.IndexOf("songName"));
                    string[] parameters = htmlPostData.Split('&');
                    string[] inputs = new string[5];
                    for (int i=0; i<parameters.Length; i++)
                    {
                        inputs[i] = (parameters[i].Split('='))[1];
                        inputs[i] = inputs[i].Replace('+',' ');
                    }
...
    byte[] outbuffer = Encoding.ASCII.GetBytes(answerPage.ToString());
                    sock.Send(outbuffer);
                    Console.WriteLine("Results Sent");
                    sock.Close();
