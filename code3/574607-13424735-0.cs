		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
		private const int WM_SETREDRAW = 0xB;
		private void PanelView_Scroll(object sender, ScrollEventArgs e)
		{
			Control control = sender as Control;
			if (control!=null)
			{
				if (e.Type == ScrollEventType.ThumbTrack)
				{
					// Enable drawing
					SendMessage(control.Handle, WM_SETREDRAW, 1, 0);
					// Refresh the control 
					control.Refresh();
					// Disable drawing                            
					SendMessage(control.Handle, WM_SETREDRAW, 0, 0);
				}
				else
				{
					// Enable drawing
					SendMessage(control.Handle, WM_SETREDRAW, 1, 0);
					control.Invalidate();
				}
			}
		}
