    void UpdateMessage (string message)
    {
      Action action = () => txtMessage.Text = message;
      this.Invoke (action);
    }
