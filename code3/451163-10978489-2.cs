    GameSession session = XLiveGameManager.CreateSession("XXXXXXXXXXXXXXX");
    manager = new XLiveFormManager(this, session);
    session.CreateSessionCompleted += new AsyncEventHandler(session_CreateSessionCompleted);
    session.Open();
    
    manager.GameStateChanged += new XLiveFormManager.XLiveGameStateEventHandler(manager_GameStateChanged);
    manager.NewGameEvent += new EventHandler(manager_NewGameEvent);
    manager.ContinueGameEvent += new EventHandler(manager_ContinueGameEvent);
    manager.LeaveGameEvent += new EventHandler(manager_LeaveGameEvent);
