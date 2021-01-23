	     	using System.ComponentModel;
		namespace WpfApplication1
		{
			public sealed class TextVM : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;
				private TextInfo _info;
				public TextVM()
				{
					_info = new TextInfo();
				}
				public string MyText 
				{
					get { return _info.MyText; }
					set
					{
						_info.MyText = value;
						OnPropertyChanged("MyText");
					}
				}
				private void OnPropertyChanged(string p)
				{
					PropertyChangedEventHandler handler = PropertyChanged;
					if (handler != null)
					{
						handler(this, new PropertyChangedEventArgs(p));
					}
				}
			}
		}
		using System;
		namespace WpfApplication1
		{
			public sealed class TextInfo
			{
				public TextInfo()
				{
					MyText = String.Empty;
				}
				public string MyText { get; set; }
			}
		}
