	using System;
	using System.Windows;
	using System.Timers;
	using System.Collections.ObjectModel;
	using System.Windows.Threading;
	using System.ComponentModel;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			Timer _timer = null;
			ObservableCollection<CustomMessage> _messages = null;
			int count = 0;
			public MainWindow()
			{
				InitializeComponent();
				_messages = new ObservableCollection<CustomMessage>();
				count++;
				_messages.Add(new CustomMessage() { ID = count, Message = "Message" });
				_timer = new Timer(1000);
				_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
				this.DGNew.ItemsSource = _messages;
				_timer.Start();
			}
			void _timer_Elapsed(object sender, ElapsedEventArgs e)
			{
				try
				{
					_timer.Stop();
					Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
					{
						if (this.CBAdd.IsChecked == true)
						{
							count++;
							_messages.Add(new CustomMessage() { ID = count, Message = "Timer Message " + count });
						}
						else
						{
							// Udpate existing Message
							Random random = new Random();
							CustomMessage message = _messages[random.Next(0, count)];
							message.Message = "Updated Time" + DateTime.Now.ToLongTimeString();
						}
					}));
				}
				finally
				{
					_timer.Start();
				}
			}
		}
		public class CustomMessage : INotifyPropertyChanged
		{
			private int _ID;
			public int ID
			{
				get { return _ID; }
				set
				{
					_ID = value;
					OnPropertyChanged("ID");
				}
			}
			private string _Message;
			public string Message
			{
				get { return _Message; }
				set
				{
					_Message = value;
					OnPropertyChanged("Message");
				}
			}
			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged(string propertyName)
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
