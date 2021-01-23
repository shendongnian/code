	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Navigation;
	using System.Windows.Shapes;
	using System.ComponentModel;
	using System.Threading;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
			private void Window_Loaded(object sender, RoutedEventArgs e)
			{
				BusyIndicator.IsBusy = true;
				BusyIndicator.BusyContent = "Initializing...";
				BackgroundWorker worker = new BackgroundWorker();
				worker.DoWork += (o, a) =>
					{
						for (int index = 0; index < 5; index++)
						{
							Dispatcher.Invoke(new Action(() =>
							{
								BusyIndicator.BusyContent = "Loop : " + index;
							}), null);
							Thread.Sleep(new TimeSpan(0, 0, 1));
						}
					};
				worker.RunWorkerCompleted += (o, a) =>
					{
						BusyIndicator.IsBusy = false;
					};
				worker.RunWorkerAsync();
			}
		}
	}
