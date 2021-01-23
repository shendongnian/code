      List<System.Threading.Timer> TimerList = new List<System.Threading.Timer>();
      Timer stateTimer = new Timer(tcb, autoEvent, 1000, 250);
      Timer responseTimer = new Timer(tcb, autoEvent, 1000, 250);  
      TimerList.add(stateTimer);
      TimerList.add(responseTimer);
    foreach (System.Threading.Timer t in TimerList)
    {
      T.Change(TimeSpan(0), new(TimeSpan(0));
    }
     
