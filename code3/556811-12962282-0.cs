		private delegate void SetTextDeleg(string text);
		void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			string data = serialPort1.ReadExisting();	
			// Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.
			// ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.
			this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
		}
		private void si_DataReceived(string data) { textBox1.Text = data.Trim(); }
		
