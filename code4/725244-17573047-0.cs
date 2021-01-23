    public void StopListener()
    {
        this.listening = false;            
        listener .Close();   // forcibly end communication 
    }
