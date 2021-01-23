    private void Looper()
        {
            int i = 0;
            int AttemptCount = 1;
            while (i == 0)
            {
                try
                {
                    TcpListener tL = new TcpListener(Network.GetLocalIPAddress(), 56009);
                    tL.Start(10);
                    Socket tS = tL.AcceptSocket();
                    if (tS.Connected)
                    {
                        NetworkStream nS = new NetworkStream(tS);
                        StreamReader Reader = new StreamReader(nS);
                        Output = Reader.ReadToEnd().Trim();
                        Reader.Close();
                        nS.Close();
                        tS.Close();
                        tL.Stop();
                        //If Done, End Execution
                        i = 1;
                    }
                    else
                    {
                        MessageBox.Show("The connection to the client is broken or failed..!!\n\nPlease check connection and try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                catch (SystemException ex)
                {
                    //If Not, Loop Execution Again
                    if (MessageBox.Show("Exception: " + ex.Message + "\n\nAttempt Count: " + AttemptCount + "\n\nDo you want to terminate the transmission?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        i = 1;
                        ResetTimer.Stop();
                    }
                    else
                    {
                        i = 0;
                        AttemptCount++;
                    }
                }
            }
        }
