    private Stopwatch _sw = new Stopwatch();
    
    public void StartOrResumeGame() {
        _sw.Start();
    }
    public void StopOrPauseGame() {
        _sw.Stop();
        _gameTimeMessage = String.Format("You have been playing for {0} seconds.", _sw.TotalSeconds);
    }
