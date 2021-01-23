    public partial class myForm : Form
    {
        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();
    //constructor. populates the items. Assumes there is a listbox (myListbox) and a textbox (myTextbox), named respectively
    public myForm()
    {
        InitializeComponent();
        myDictionary.Add("key1", "item1");
        myDictionary.Add("key2", "My Item");
        myDictionary.Add("key3", "A Thing");
    
        //populate the listbox with everything in the dictionary
        foreach (string s in myDictionary.Values)
            myListbox.Add(s);
    }
    //make sure to connect this to the textbox change event
    private void myTextBox_TextChanged(object sender, EventArgs e)
    {
    	myListbox.BeginUpdate();
    	myListbox.Items.Clear();
    	foreach (string s in myDictionary.Values)
    	{
    		if (s.Contains(myListbox.Text))
    			myListbox.Items.Add(s);
    	}
    	myListbox.EndUpdate();
    }
    }
