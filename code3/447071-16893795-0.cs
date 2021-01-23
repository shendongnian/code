    LoadingScreen frmLoadingScreen = new LoadingScreen();
    .....
    bkwNetworkConnector.RunWorkerAsync();
    
    frmLoadingScreen.ShowDialog();
    
     /***********************************************************************************************************************/
            private void bkwNetworkConnector_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    hostSocket = new TcpClient();
                    hostSocket.Connect(strIp, intPort);
                }
                catch (Exception exp)
                {
                    
                }
            }
            
            private void bkwNetworkConnector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                frmLoadingScreen.Close();
               
            }
            
