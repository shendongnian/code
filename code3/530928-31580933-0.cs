    	protected override void WndProc(ref Message m)
		{
			FormWindowState org = this.WindowState;
			base.WndProc(ref m);
			if (this.WindowState != org)
				this.OnFormWindowStateChanged(EventArgs.Empty);
		}
		protected virtual void OnFormWindowStateChanged(EventArgs e)
		{
			// Do your stuff
		}
