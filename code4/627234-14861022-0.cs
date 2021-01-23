    Thread thread = new Thread(new ThreadStart(delegate
    {
        Invoke((Action)(()=>{ button_login.Text = WORKING; Loading(ShowMode.show, pictureBox_login_loading); });
        // send request         
        client = new TcpClient();
        try
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            client.Connect(endPoint);
            // send login details .. :)
            output = client.GetStream();
            writer = new BinaryWriter(output);
            reader = new BinaryReader(output);
            // write details
            writer.Write("login"   "|"   userID   "|"   privateName);
         }
         catch (Exception)
         {
             MessageBox.Show("Server is down.");
             return;
         }
         finally
         {
             // Stop loading and return status
             Invoke((Action)(()=>{ button_login.Text = DEFAULT_LOGIN_TEXT; Loading(ShowMode.hide, pictureBox_login_loading); }));
          } 
    }));
    thread.Start();
