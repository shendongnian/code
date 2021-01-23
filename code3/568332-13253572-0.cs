    public partial class Form1 : Form
	{
		private const int WM_ACTIVATEAPP = 0x001C;
		private const int DBT_DEVICEARRIVAL = 0x8000;               // system detected a new device      
		private const int DBT_DEVICEREMOVEPENDING = 0x8003;         // about to remove, still available      
		private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;  
		private bool appActive = true;
		public Form1()
		{
			this.Size = new System.Drawing.Size(300, 300);
			this.Text = "Form1";
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			// Paint a string in different styles depending on whether the 
			// application is active. 
			if (appActive)
			{
				e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, 20, 20, 260, 50);
				e.Graphics.DrawString("Application is active", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
			}
			else
			{
				e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, 20, 20, 260, 50);
				e.Graphics.DrawString("Application is Inactive", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
			}
		}
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
		protected override void WndProc(ref Message m)
		{
			// Listen for operating system messages. 
			switch (m.Msg)
			{
				// The WM_ACTIVATEAPP message occurs when the application 
				// becomes the active application or becomes inactive. 
				case WM_ACTIVATEAPP:
					// The WParam value identifies what is occurring.
					appActive = (((int)m.WParam != 0));
					// Invalidate to get new text painted. 
					this.Invalidate();
					break;
				case DBT_DEVICEARRIVAL:
					MessageBox.Show("Connected!");
					break;
				case DBT_DEVICEREMOVECOMPLETE:
					MessageBox.Show("Disconnected!");
					break;
			}
			base.WndProc(ref m);
		}
	}
