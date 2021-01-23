    class InternetConnector  
    {  
        private struct ConnectionData
        {
            public Action<Exception> ErrorHandler { get; set; }
            public Socket Socket { get; set; }
        }
        public void ConnectToHost(Action<Exception> errorHandler)  
        {  
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(connector_host), connector_port);  
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var connectionData = new ConnectionData { ErrorHandler = errorHandler, Socket = client };
  
            client.Blocking = true;  
            client.BeginConnect(ip, new AsyncCallback(ConnectCallback), connectionData);  
        }  
  
        private static void ConnectCallback(IAsyncResult ar)  
        {  
            ConnectionData connectionData = new ConnectionData();
            try  
            {  
                connectionData = (ConnectionData)ar.AsyncState;  
                connectionData.Socket.EndConnect(ar);  
                connectDone.Set();  
                Connected = true;  
            }  
            catch (Exception e)  
            {  
                if (connectionData.ErrorHandler != null)
                    connectionData.ErrorHandler(e);
            }  
        }  
    }  
    public partial class Form1 : Form       
    {       
        private bool isRunning = false;       
        private InternetConnector client = new InternetConnector();       
       
        private void AsyncErrorHandler(Exception e)
        {
            if (status.InvokeRequired)
            {
                // queue a call to ourself on control's UI thread and immediately return
                status.BeginInvoke(new Action(()=>AsyncErrorHandler(e)));
                return;
            }
            // we are on the right thread to set the status text
            status.Text = "Async Error: " + ex.Message;  
        }
 
        private void startStop_Click(object sender, EventArgs e)       
        {       
            try       
            {       
                if (!isRunning || !InternetConnector.Connected)       
                {       
                    if (!InternetConnector.Connected)       
                    {       
                        client.SetAddress(ipAddress.Text);       
                        client.SetPort(Convert.ToInt32(connectionport.Text));       
                        // connect, pass in the method to use for error reporting
                        client.ConnectToHost(AsyncErrorHandler);       
                        status.Text = "Signals Receiver: Connected";       
                        status.ForeColor = Color.Green;       
                        startStop.Text = "Stop";       
                        isRunning = true;       
                    }       
                    else       
                    {       
                        startStop.Text = "Start";       
                        client.DisconnectFromHost();       
                        isRunning = false;       
                    }       
                }       
            }       
            catch(Exception ex)       
            {       
                status.Text = "Socket Error: " + ex.Message;       
            }       
        }       
    }       
