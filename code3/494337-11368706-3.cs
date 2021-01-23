	private bool WaitForDocumentCompleted(int seconds)
		{
			int counter = 0;
			while (Program.BrowsingSystem.IsBusy)
			{
				Application.DoEvents();
				Thread.Sleep(1000);
				if (counter == seconds)
				{
				return true;
				}
				counter++;
			}
			return true;
		}
