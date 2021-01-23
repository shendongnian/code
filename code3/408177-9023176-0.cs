    private void CallBack(IAsyncResult result) 
    { 
        var client = (TcpClient)result.AsyncState; 
        bool connected = false;
        try
        {
            client.EndConnect(result);
            connected = client.Connected;
        }
        catch (SocketException)
        {
        }
        catch (ObjectDisposedException)
        {
        }
        finally
        {
            if (client.Connected)
            {
                client.Close();
            }
            
            client.Dispose();
        }
     
        if (connected) 
        { 
            this.Invoke((MethodInvoker)delegate 
            { 
                txtDisplay.Text += "open2" + Environment.NewLine; 
            }); 
        } 
        else 
        { 
            this.Invoke((MethodInvoker)delegate 
            { 
                txtDisplay.Text += "closed2" + Environment.NewLine; 
            }); 
        } 
    } 
