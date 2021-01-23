	public class listItems: INotifyPropertyChanged
	{
		bool _selected = false;
		public bool isSelected
		{
			get { return _selected; }
			set 
			{
				if( value == _selected )
					return;
				_selected = value;
				var pc = this.PropertyChanged;
				if( null != pc )
					pc( this, new PropertyChangedEventArgs( "ImageSource" ) );
			}
		}
		public string ImageSource { get { return _selected ? "Images/yellow.png" : "Images/black.png"; } }
		public event PropertyChangedEventHandler PropertyChanged;
	}
