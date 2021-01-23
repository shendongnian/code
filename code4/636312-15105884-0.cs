    enum AutoRingStatus { Polling, Waiting }
    
    AutoRingStatus _autoRingStatus = AutoRingStatus.Polling;
    DateTime _autoRingWaitingTill = DateTime.Now;
    private void autoRing(Object obj) {
    	TimeSpan ts = timeWatch.Elapsed;
    
    	if (ts.Minutes == bellMinutesFirst && ts.Seconds == bellSeconds || ts.Minutes == bellMinutesSecond && ts.Seconds == bellSeconds) {
    		if (_autoRingStatus == AutoRingStatus.Polling) {
    			btnSound_Click_1(null, null);
    			_autoRingStatus = AutoRingStatus.Waiting;
    			_autoRingWaitingTill = DateTime.Now.AddSecond(30);
    		} else {
    			if (_autoRingWaitingTill <= DateTime.Now) {
    				_autoRingStatus = AutoRingStatus.Polling;
    			} else {
    				// Waiting for the 30s to pass...
    			}
    		}
    	}
    }
