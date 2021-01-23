    public void SetBinding(BindingList<string> messages)
    {
      // BindingList<string> toBind = new BindingList<string>(messages);
      lbMessages.DataSource = messages;
    }
