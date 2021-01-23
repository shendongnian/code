	public Form1()
	{
	    InitializeComponent();
	    _items.Add("One"); // <-- Add these
	    _items.Add("Two");
	    _items.Add("Three");
	    listBox1.DataSource = _items;
	}
