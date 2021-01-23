    DeliverMessageThread_DoWork
    {
      while(true)
      {
        if(GetNextMessage() == null)
          MyAutoResetEvent.WaitOne(); // The thread will suspend here until the ARE is signalled
        else
        {
          DeliverMessage();
          Thread.Sleep(10); // Give something else a chance to do something
         }
      }
    }
    
    MessageGenerator_NewMessageArrived(object sender, EventArgs e)
    {
       MyAutoResetEvent.Set(); // If the deliver message thread is suspended, it will carry on now until there are no more messages to send
    }
