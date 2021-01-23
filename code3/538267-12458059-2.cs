    private enum WTS
    {
            CONSOLE_CONNECT = 1,
            CONSOLE_DISCONNECT = 2,
            REMOTE_CONNECT = 3,
            REMOTE_DISCONNECT = 4,
            SESSION_LOGON = 5,
            SESSION_LOGOFF = 6,
            SESSION_LOCK = 7,
            SESSION_UNLOCK = 8,
            SESSION_REMOTE_CONTROL = 9
     }
    
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
    	switch (m.Msg) {
    		case WM_WTSSESSION_CHANGE:
    			switch (m.WParam.ToInt32) {
    				case WTS.CONSOLE_CONNECT:
    					//MessageBox.Show("A session was connected to the console session.");
    					
    					break;
    				case WTS.CONSOLE_DISCONNECT:
    					//MessageBox.Show("A session was disconnected from the console session.");
    					
    					break;
    				case WTS.REMOTE_CONNECT:
    					break;
    				//MessageBox.Show("A session was connected to the remote session.");
    				case WTS.REMOTE_DISCONNECT:
    					break;
    				//MessageBox.Show("A session was disconnected from the remote session.");
    				case WTS.SESSION_LOGON:
    					
    					break;
    				//MessageBox.Show("A user has logged on to the session.")
    				case WTS.SESSION_LOGOFF:
    					//MessageBox.Show("A user has logged off the session.");
    					
    					break;
    				case WTS.SESSION_LOCK:
    					//MessageBox.Show("A session has been locked.")
    					
    					break;
    				case WTS.SESSION_UNLOCK:
    					//MessageBox.Show("A session has been unlocked.")
    					
    					break;
    				case WTS.SESSION_REMOTE_CONTROL:
    					MessageBox.Show("A session has changed its remote controlled status. To determine the status, call GetSystemMetrics and check the SM_REMOTECONTROL metric.");
    					break;
    			}
    
    			break;
    	}
    
    	base.WndProc(m);
    }
