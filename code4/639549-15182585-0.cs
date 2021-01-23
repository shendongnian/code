    //add callback 
    smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
    
    //set token
    string userToken = "tokenString";
    
    //send asynchronously
    smtpCient.SendAsync(message, userToken);
    public static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
            {
                // Get the unique identifier for this asynchronous operation.
                 String token = (string) e.UserState;
           
                if (e.Cancelled)
                {
                     //do something if it was cancelled
                }
                if (e.Error != null)
                {
                   MessageBox.Show( e.Error.ToString());
                } else
                {
                    MessageBox.Show("Message sent.");
                }
            }
