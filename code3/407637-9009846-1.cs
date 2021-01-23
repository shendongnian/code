    public void AddItemToList(string Item)
    {
       if(InvokeRequired)
          Invoke(new Action<string>(AddItemToList), Item);
       else
          listBox1.Add(Item);
    }
