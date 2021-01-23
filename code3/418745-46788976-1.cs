	class BindingProxy : Freezable
	{
		//Override of Freezable
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxy();
		}
		public object Data
		{
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
	}
	public class Column : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected internal void OnPropertyChanged(string propertyname)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
		}
		public DataGridLength Width
		{
			get { return m_width; }
			set { m_width = value; OnPropertyChanged("Width"); }
		}
		DataGridLength m_width;
	}
