    public string GetMessageLog()
    {
        string message = CheckForMessages();
        if (message != "") {
          ListBox1.Items.Add(message);      
        return DateTime.Now.ToLongTimeString();
    }
