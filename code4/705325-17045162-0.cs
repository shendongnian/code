    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;
    namespace WpfApplication4
    {
        public class MainViewModel : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged = delegate { };
			private int mCounter;
			public int Counter
			{
				get { return mCounter; }
				set
				{
					mCounter = value;
					PropertyChanged(this, new PropertyChangedEventArgs("Counter"));
				}
			}
			public void Start()
			{
				for(int i = 0; i <= 100; i++)
				{
					Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind,
									(Action)(() =>
									{
										Counter = i;
									}));
					Thread.Sleep(100);
				}
			}
		}
	}
