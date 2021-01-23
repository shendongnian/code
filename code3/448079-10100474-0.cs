    private int _timerCounter = 0;
    private void ITItimers_Tick(object sender, EventArgs e)
    {
        if( _timersCounter++ == 5 ) {
             OnTimerFired20TimesEvent();
             _timersCounter = 0;
        }
    
        ITIpanel.Visible = false;
        // ...
    }
