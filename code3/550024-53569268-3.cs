    public class ThreadPauseState {
    	private object _lock = new object();
    	private bool _paused = false;
    		
    	public bool Paused {
    		get { return _paused; }
    		set {
    			if(_paused != value) {
    				if(value) {
    					Monitor.Enter(_lock);
    					_paused = true;
    				} else {
    					_paused = false;
    					Monitor.Exit(_lock);
    				}
    			}
    		}
    	}
    
    	public void Wait() {
    		lock(_lock) { }
    	}
    }
