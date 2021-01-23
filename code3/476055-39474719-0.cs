         private void QueuePeekCompleted(object sender, PeekCompletedEventArgs e)
         {
            try
            {
                var message = myQueue.EndPeek(e.AsyncResult);
                //LogInfo("Received this : " + message.Body);
            }
            catch (Exception ex)
            {
                //LogError(ex);
            }
            myQueue.Receive();
            myQueue.BeginPeek();
        }
