    public class ChannelWrapper : INotifyPropertyChanged
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
		private object comboBox1SelectedItem;
		public object ComboBox1SelectedItem
		{
			get { return this.comboBox1SelectedItem; }
			set
			{
				if (this.comboBox1SelectedItem != value)
				{
					this.comboBox1SelectedItem = value;
					this.OnPropertyChanged("ComboBox1SelectedItem");
					// Put the logic to change the items available in the second combobox here
					if (value == "Value1")
						this.ComboBox2ItemsSource = new List<object>() { "Setting1", "Setting2" };
					if (value == "Value2")
						this.ComboBox2ItemsSource = new List<object>() { "Setting3", "Setting4" };
				}
			}
		}
		private List<object> comboBox2ItemsSource;
		public List<object> ComboBox2ItemsSource
		{
			get { return this.comboBox2ItemsSource; }
			set
			{
				if (this.comboBox2ItemsSource != value)
				{
					this.comboBox2ItemsSource = value;
					this.OnPropertyChanged("ComboBox2ItemsSource");
				}
			}
		}
		public Channel Ch { get; set; }
	}
