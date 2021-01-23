    namespace PhoneApp1
    {
	public partial class MainPage : PhoneApplicationPage
	{
		private TB currentItem;
		ListBox mylistbox;
		// Constructor
		public MainPage()
		{
			InitializeComponent();
			// here, for illustration purposes,  I have declared and instantiated a listbox in the code-behind, 
			// normally the declaration and initialization is done by auto-generated code, 
			// when you have dropped the list into your GUI via the designer...
			// although the actual adding of items is either populated in code-behind 
			// or is accomplished by binding to a source in the designer.
			this.mylistbox = new ListBox();
			this.currentItem = null;
			// add some items...
			TB[] tbs = new TB[] { new TB(), new TB(), new TB() };
			this.mylistbox.ItemsSource = tbs;
			// subscribe to the SelectionChanged event...
			this.mylistbox.SelectionChanged += new SelectionChangedEventHandler(mylistbox_SelectionChanged);
			this.mylistbox.Hold += new EventHandler<GestureEventArgs>(mylistbox_Hold);
		}
		void mylistbox_Hold(object sender, GestureEventArgs e)
		{
			if (this.currentItem == null) { return; }
			this.currentItem.F_Color = "Yellow";
		}
		// respond to the SelectionChanged event...
		void mylistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.currentItem = ((ListBox)sender).SelectedItem as TB;;
		}
	}
	public class TB
	{
		public string F_Name { get; set; }
		public string F_Color { get; set; }
	}  
}
