    private void YTready(string playerID)
    {
    	YTState = true;
    	//start eventHandlers
    	YTplayer_CallFlash("addEventListener(\"onStateChange\",\"YTStateChange\")");
    	YTplayer_CallFlash("addEventListener(\"onError\",\"YTError\")");
    }
    private void YTStateChange(string YTplayState)
    {
    	switch (int.Parse(YTplayState))
    	{
    		case -1: playState = false; break; //not started yet
    		case 1: playState = true; break; //playing
    		case 2: playState = false; break; //paused
    		//case 3: ; break; //buffering
    		case 0: playState = false; if (!loopFile) mediaNext(); else YTplayer_CallFlash("seekTo(0)"); break; //ended
    	}
    }
    private void YTStateError(string error)
    {
    	Console.Write("YTplayer_error: "+error+"\r\n");
    }
