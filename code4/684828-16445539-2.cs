            mySqlConnectionString = String.Format("server={0};user={1};database=MTA;port=3306;password={2}", SqlHost, mySqlUser, mySqlPass);
            se = new SshExec(Host, User, Pass);
            msc = new MySqlConnection(mySqlConnectionString);
            // Connect to server and get the list of firmware versions and serial numbers available
            se.Connect();
            lblConnected.Text = (se.Connected) ? "Connected" : "Not Connected";
            try
            {
                msc.Open();  //exception happens here
            }
            catch (Exception)
            {
                //do stuff, i.e. retry connection
                try
                {
                    msc.Open();  //exception happens here
                }
                catch (Exception)
                {
                    //do stuff
                }
            }
