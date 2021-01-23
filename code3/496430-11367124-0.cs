	public class SeriaCollection : ObservableCollection<Seria>
	{
		public AxeLabels XaxeLabels { get; set; }
		public AxeLabels YaxeLabels { get; set; }
		public SeriaCollection()
		{
			XaxeLabels = new AxeLabels();
			YaxeLabels = new AxeLabels();
		}
	}
