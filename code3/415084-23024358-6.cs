    using System.Windows.Input;
    using System.Windows.Threading;
      namespace System.Windows.Controls{
    	class RussianCanvas : Canvas{
    		
    		public event MouseButtonEventHandler MouseDoubleClick;
    		private bool doubleClickStarted;
    		private DispatcherTimer doubleClickTimer;
    		private const long DOUBLE_CLICK_INTERVAL = 2000000;
    
    		public RussianCanvas() : base(){    
    			doubleClickStarted = false;
    			doubleClickTimer = new DispatcherTimer();
    			doubleClickTimer.Interval = new TimeSpan(DOUBLE_CLICK_INTERVAL);
    			doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);
    			MouseUp += new MouseButtonEventHandler(mouseUpReaction);
    		}
    
    		private void mouseUpReaction(object sender, MouseButtonEventArgs e){
    			if(doubleClickStarted) { 
    				doubleClickStarted =false; 
    				if(MouseDoubleClick!=null)
    					MouseDoubleClick(sender, e);
    			}
    			else{ 
    				doubleClickStarted =true;
    				doubleClickTimer.Start();				
    			}
    		}
    		private void doubleClickTimer_Tick(object sender, EventArgs e){
    			doubleClickStarted = false; doubleClickTimer.Stop();
    		}
    	}
    }
