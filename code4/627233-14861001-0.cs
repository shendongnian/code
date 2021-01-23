           button_login.Text = WORKING;
            Loading(ShowMode.show, pictureBox_login_loading);
            // send request      
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler((obj, args) =>
            {
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
                    this.Invoke(new Action(() =>MessageBox.Show("Server is down."));
                }
            });
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, args) =>
            {
                button_login.Text = DEFAULT_LOGIN_TEXT;
                Loading(ShowMode.hide, pictureBox_login,loading);
            });
            worker.RunWorkerAsync();
