    public void AddMessageAsync(string message)
    {
         BeginInvoke(new Action<string>(msg)=> 
             listView1.Items.Add(additional + msg, icon), message);
    }
