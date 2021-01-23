        public class myMouseClass: IMessageFilter //Must implement IMessageFilter
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
			public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
            //Constants 
			private const int MOUSEEVENTF_LEFTDOWN = 0x02;
			private const int MOUSEEVENTF_LEFTUP = 0x04;
			private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
			private const int MOUSEEVENTF_RIGHTUP = 0x10;
            private const int WM_MOUSEMOVE = 0x0200;
			private int Threshold = 20; //how far the mouse should move to reset timer
			private int StartLocationX = 0; //stores starting X value
			private int StartLocationY = 0; //stores starting Y value
			private Timer timerHold = new Timer(); //timer to trigger mouse click
            //Start Mouse monitoring by calling this. This will also set the timer.		
			private void StartFilterMouseEvents()
            {
 
			    timerHold.Interval = 1000; //how long mouse must be in threshold.
				timerHold.Tick = new EventHandler(timerHold_Tick);
                Application.AddMessageFilter((IMessageFilter) this);
            }
            //Stop Mouse monitoring by calling this and unset the timer.
			private void StopFilterMouseEvents()
            {
                timerHold.Stop();
                timerHold -= timerHold_Tick;
                Application.RemoveMessageFilter((IMessageFilter) this);
            }
            //This will start when Application.AddMessageFilter() is called
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
					if((Cursor.Position.X > StartLocationX + 20)||(Cursor.Position.X > StartLocationX - 20))&&
					       ((Cursor.Position.Y > StartLocationY + 20)||(Cursor.Position.Y > StartLocationY - 20))
						   {
						        timerHold.Stop(); //stops timer if running
						        timerHold.Start(); //starts it again with new position.
								StartLocationX = Cursor.Position.X;
								StartLocationY = Cursor.Position.Y;
						   }
                }
                return false;
            }
            //This event gets fired when the timer has not been reset for 1000ms
			public void timerHold_Tick(object sender, EventArgs e)
			{
				mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			}
          }
