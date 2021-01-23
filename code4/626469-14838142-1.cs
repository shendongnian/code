	class OtherDll
	{
		public OtherDll()
		{
			TriggerWatcherDll.TriggerChanged += TriggerWatcherDll_TriggerChanged;
		}
		void TriggerWatcherDll_TriggerChanged(object sender, EventArgs e)
		{
			if (TriggerWatcherDll.IsTriggerOn)
				System.Windows.Forms.MessageBox.Show("Trigger is ON!");
		}
	}
