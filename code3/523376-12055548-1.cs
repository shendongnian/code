    ///// myClass (working thread...)
    class myClass
    {
        public event EventHandler NewListEntry;
    
    	public void ThreadMethod()
        {
            DoSomething();
        }
    
    	protected virtual void OnNewListEntry(MyEventArgs e)
        {
            EventHandler newListEntry = NewListEntry;
            if (newListEntry != null)
            {
                newListEntry(this, e);
            }
        }
    	
    	private void DoSomething()
    	{
    		///// Do some things and generate strings, such as "test"...
    		string test = "test";
    		
    		OnNewListEntry(new MyEventArgs(test));
    	}
    }
