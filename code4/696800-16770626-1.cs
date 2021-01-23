	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		bool found = false;
                var worker = sender as BackgroundWorker;
		while (!worker.CancellationPending && !found)
		{
			MifareReader.CommPort = 4;
			MifareReader.PortOpen = true;
			MifareReader.mfAutoMode(true);               
			MifareReader.mfRequest();                
			if (CardID == "0" || CardID == string.Empty)
			{
				MifareReader.mfRequest();
				CardID = MifareReader.mfAnticollision().ToString();
				MifareReader.mfHalt();
			}
			else
			{
				e.Result = ObrnutiID;
				found = true;
				MifareCitac.mfHalt();
			}
		}
		if (worker.CancellationPending)
		{
			e.Cancel = true;
		}
	}
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // The user canceled the operation.
                MessageBox.Show("Operation was canceled");
            }
            else if (e.Error != null)
            {
                // There was an error during the operation. 
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                // The operation completed normally. 
                string msg = String.Format("Result = {0}", e.Result);
                MessageBox.Show(msg);
            }
            this.Close() // Closes the form.
        }
