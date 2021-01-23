    namespace PhoneApp1
    {
        public partial class MainPage : PhoneApplicationPage
	    {
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
	    		// add some items...
	    		TB[] tbs = new TB[] { new TB(), new TB(), new TB() };
	    		this.mylistbox.ItemsSource = tbs;
	    		// subscribe to the SelectionChanged event...
	    		this.mylistbox.SelectionChanged += new SelectionChangedEventHandler(mylistbox_SelectionChanged);
	    	}
	    	// respond to the SelectionChanged event...
	    	void mylistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	    	{
	    		TB tb = this.mylistbox.SelectedItem as TB;
	    		if (tb == null) { return; }
    
    			// the 'as' operator allows for a safe way of testing what we are using before we use it...
    			// we passed the validation, so now we can do what we like with the type...
    			// the selected TB item is being operated upon here, but that does not stop it from being an item in the list.
    			// this means whatever we 'do' to it here, is actually 'doing' it to the selected item in the list.
    			tb.F_Color = "Yellow";
    		}
    	}
    	public class TB
    	{
    		public string F_Name { get; set; }
    		public string F_Color { get; set; }
    	}  
    }
