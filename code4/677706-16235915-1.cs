    public void dumpList()
    {
        this.Dispatcher.Invoke(new Action(()=>
       {    
        ListBoxS.DataSource = sl.dump(); //Returns a List<string>()
       }));
    }
