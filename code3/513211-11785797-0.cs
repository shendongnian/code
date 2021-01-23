    bool IsPaused;
    bool IsKeyPaused;
    
    void Pause(){}
    void UnPause(){}
    void KeyDown(){
        if(!IsPaused)
        {
            IsPaused = true;
            IsKeyPaused = true;
            Pause();
        }
    }
    void KeyUp(){
        if(IsKeyPaused)
        {
            IsPaused = false;
            IsKeyPaused = false;
            UnPause();
        }
    }
    void TimerPause(){
        if(!IsPaused)
        {
            IsPaused = true;
            Pause();
        }
    }
    void TimerEnd(){
         UnPause();
    }
