	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new GameWindow());
		}
		class GameWindow : Form
		{
			private Thread _gameThread;
			private ManualResetEvent _evExit;
			public GameWindow()
			{
				Text			= "Pong";
				Size			= new Size(800, 600);
				StartPosition	= FormStartPosition.CenterScreen;
				FormBorderStyle	= FormBorderStyle.Fixed3D;
				DoubleBuffered	= true;
				SetStyle(
					ControlStyles.AllPaintingInWmPaint |
					ControlStyles.OptimizedDoubleBuffer |
					ControlStyles.UserPaint,
					true);
			}
			private void GameThreadProc()
			{
				IAsyncResult tick = null;
				if(!_evExit.WaitOne(15))
				{
					if(tick != null)
					{
						if(!tick.AsyncWaitHandle.WaitOne(0))
						{
							// we are running too slow, maybe we can do something about it
							tick.AsyncWaitHandle.WaitOne();
						}
					}
					tick = BeginInvoke(new MethodInvoker(OnGameTimerTick));
				}
			}
			private void OnGameTimerTick()
			{
				// perform game physics here
				// don't draw anything
				Invalidate();
			}
			private void ExitGame()
			{
				Close();
			}
			protected override void OnPaint(PaintEventArgs e)
			{
				var g = e.Graphics;
				g.Clear(Color.White);
				// do all painting here
				// don't do your own double-buffering here, it is working already
				// don't dispose g
			}
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				_evExit = new ManualResetEvent(false);
				_gameThread = new Thread(GameThreadProc);
				_gameThread.Name = "Game Thread";
				_gameThread.Start();
			}
			protected override void OnClosed(EventArgs e)
			{
				_evExit.Set();
				_gameThread.Join();
				_evExit.Close();
				base.OnClosed(e);
			}
			protected override void OnPaintBackground(PaintEventArgs e)
			{
				// do nothing
			}
		}
	}
