    public enum GameStates
    {
        NoRunningAllowed=0,
        Stopped,
        ReadyForRestart,
        EndNextGame,
        Running
    }
    ///...other stuff...
    var GameStateList = new Dictionary<GameStates,string>();
    GameStateList.Add(GameStates.NoRunningAllowed,"NO RUN ALLOWED");
    GameStateList.Add(GameStates.Stopped,"STOPPED");
    GameStateList.Add(GameStates.ReadyForRestart,"READY FOR RESTART");
    GameStateList.Add(GameStates.EndNextGame,"END NEXT GAME");
    GameStateList.Add(GameStates.Running,"RUNNING");
    string debugMessageForCurrentState = GateStateList[MyCurrentGameState];
