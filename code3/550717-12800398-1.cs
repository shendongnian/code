    private void quit()
    {
        if (DateTime.Now.Subtract(_lastQuitTime).TotalSeconds > 5)
        {
               
              //Prompt the user
              //Reset the timeout
              _lastQuitTime = DateTime.Now;
        }
    }
