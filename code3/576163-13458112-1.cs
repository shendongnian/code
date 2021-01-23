    public class ViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged values
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		public ActionCommand Command { get; set; }
		public List<string> Elements { get; set; }
		public ViewModel()
		{
			this.Elements = new List<string>(){
				"Element1",
				"Element2"
			};
			this.Command = new ActionCommand()
			{
				ExecuteDelegate = this.Execute
			};
		}
		public void Execute(object o)
		{
			MessageBox.Show(o.ToString());
		}
	}
