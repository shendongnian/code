    private EventHandler MyEventDel;       
     
    
       public event EventHandler ExplicitEvent
        {
            add
            {
                if (MyEventDel.GetInvocationList().Count() < 10)
                {
                    MyEventDel+= value;
                }
            }
            remove
            {
                MyEventDel-= value;
            }
        }
