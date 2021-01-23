    private int messagePosition = 0;
    private string message = "This is a test";;
    public void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if(messagePosition < message.Length)
        {
            Console.Write(message[messagePosition]);
            messagePosition++;  
        }
        else 
          aTimer.Enabled = false;
    }
