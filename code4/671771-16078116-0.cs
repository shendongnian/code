	public Form1()
	{
		this.InitializeComponent();
		this.InitializeListView();
		var files = Directory.GetFiles("C:\Games\", "*.xml")
							 .Select(f => new ListViewItem(f))
							 .ToArray();
		listView.Items.AddRange(files); 
		foreach(var f in files)
		{
			this.LoadDataFromXml(f);
		}
	}
