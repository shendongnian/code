     BackgroundWorker emailInvoker = new BackgroundWorker();
     emailInvoker.DoWork += delegate
     {
         // get your clients here somehow
         foreach(string client in clients){
     
             SmtpClient client = new SmtpClient("server.com");
             // Delay to prevent flow control, try later Relay error
             Thread.Sleep(TimeSpan.FromSeconds(2));
             client.Send(message);
         }
     }
     emailInvoker.RunWorkerAsync();
