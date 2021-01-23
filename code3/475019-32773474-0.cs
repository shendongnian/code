           private void Form3_Load(object sender, EventArgs e)
        {
            sc_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip_local = new IPEndPoint(IPAddress.Loopback, 1225);
            sc_listener.Bind(ip_local);
            sc_listener.Listen(10);
            
            AsyncCallback callback = new AsyncCallback(procces_incoming_socket);
            sc_listener.BeginAccept(callback, sc_listener);
        }
            void procces_incoming_socket(IAsyncResult socket_object)
        {
            Socket sc_listener = ((Socket)socket_object.AsyncState).EndAccept(socket_object);
            AsyncCallback receive = new AsyncCallback(receive_data);
            buffer = new byte[100];
            sc_listener.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receive, sc_listener);
        }
            void receive_data(IAsyncResult socket)
        {
            // the system need to wait so i make a loop when it gets data 
             //i end the loop by flag=false
            bool flag = true;
            Socket re_socket = ((Socket)socket.AsyncState);
            while(flag)
            {
               
            int bytes_recieved = re_socket.EndReceive(socket);
            string data = UTF8Encoding.UTF8.GetString(buffer);
            if (textBox1.InvokeRequired)
            {
                // for cross thread problem
                textBox1.Invoke(new MethodInvoker(delegate { textBox1.Text = data; }));
            }
            else
            {
                textBox1.Text = data;
            }
            flag = false;
            
          
            }
            string back_data = "my pm socket back";
            byte[] buffers = new byte[50];
            buffers = UTF8Encoding.UTF8.GetBytes(back_data);
            re_socket.Send(buffers);
            // if the socket is not closed php will load for maximum required time and then error
            re_socket.Close();
    //start for next listening (O-0)
            AsyncCallback callback = new AsyncCallback(procces_incoming_socket);
            sc_listener.BeginAccept(callback, sc_listener);
        }
