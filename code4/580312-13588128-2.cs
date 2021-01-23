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
		public List<Dummy> Elements { get; set; }
		public ViewModel()
		{
			this.Elements = new List<Dummy>(){
				new Dummy() { CanSelect =true, MyProperty = "Element1"},
				new Dummy() { CanSelect =false, MyProperty = "Element2"},
				new Dummy() { CanSelect =true, MyProperty = "Element3"},
				new Dummy() { CanSelect =false, MyProperty = "Element4"},
				new Dummy() { CanSelect =true, MyProperty = "Element5"},
				new Dummy() { CanSelect =true, MyProperty = "Element6"},
				new Dummy() { CanSelect =true, MyProperty = "Element7"},
				new Dummy() { CanSelect =true, MyProperty = "Element8"},
				new Dummy() { CanSelect =false, MyProperty = "Element9"},
			};
		}
	}
	public class Dummy
	{
		public bool CanSelect { get; set; }
		public string MyProperty { get; set; }
		public override string ToString()
		{
			return this.MyProperty;
		}
	}
