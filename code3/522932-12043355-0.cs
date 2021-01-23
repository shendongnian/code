       private List<EventHandler> eventList = new List<EventHandler>();
    
       public event EventHandler Event1 
       {
          add { eventList.Add(value); }
          remove { eventList.Remove(value); }
       }
    
        private void RaiseEvent1()
    	{
    		foreach(var e in eventList)
    		{
    			e(this, EventArgs.Empty);
    		}
    	}
