	using System;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;
	namespace App1
	{
		/// <summary>
		/// An empty page that can be used on its own or navigated to within a Frame.
		/// </summary>
		public sealed partial class MainPage
		{
			//Make a place to store the timer
			private readonly DispatcherTimer _timer;
			//Make a place to store the last time the displayed item was set
			private DateTime _lastChange;
			public MainPage()
			{
				InitializeComponent();
				//Configure the timer
				_timer = new DispatcherTimer
				{
					//Set the interval between ticks (in this case 2 seconds to see it working)
					Interval = TimeSpan.FromSeconds(2)
				};
				//Change what's displayed when the timer ticks
				_timer.Tick += ChangeImage;
				//Start the timer
				_timer.Start();
			}
			/// <summary>
			/// Changes the image when the timer ticks
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="o"></param>
			private void ChangeImage(object sender, object o)
			{
				//Get the number of items in the flip view
				var totalItems = TheFlipView.Items.Count;
				//Figure out the new item's index (the current index plus one, if the next item would be out of range, go back to zero)
				var newItemIndex = (TheFlipView.SelectedIndex + 1) % totalItems;
				//Set the displayed item's index on the flip view
				TheFlipView.SelectedIndex = newItemIndex;
			}
			/// <summary>
			/// Invoked when this page is about to be displayed in a Frame.
			/// </summary>
			/// <param name="e">Event data that describes how this page was reached.  The Parameter
			/// property is typically used to configure the page.</param>
			protected override void OnNavigatedTo(NavigationEventArgs e)
			{
			}
			/// <summary>
			/// When the user changes the item displayed manually, reset the timer so we don't advance at the remainder of the last interval
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void DisplayedItemChanged(object sender, SelectionChangedEventArgs e)
			{
				//Show the time deltas...
				var currentTime = DateTime.Now;
				if (_lastChange != default(DateTime))
				{
					TimeDelta.Text = (currentTime - _lastChange).ToString();
				}
				_lastChange = currentTime;
				//Since the page is configured before the timer is, check to make sure that we've actually got a timer
				if (!ReferenceEquals(_timer, null))
				{
					_timer.Stop();
					_timer.Start();
				}
			}
		}
	}
