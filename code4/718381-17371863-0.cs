        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string[] files = System.IO.Directory.GetFiles("c:\\"); //TODO: change to the path you want
				foreach (string filename in files)
				{
					ListBox1.Items.Add(new ListItem(System.IO.Path.GetFileName(filename), filename));
				}
			}
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			ListBox2.Items.Clear();
			if (ListBox1.SelectedIndex > -1)
			{
				string filename = ListBox1.SelectedValue;
				StreamReader FileRead = new StreamReader(filename);
				string CurrentLine = "";
				//int LineCount = 0;
				while (FileRead.Peek() != -1)
				{
					CurrentLine = FileRead.ReadLine();
					ListBox2.Items.Add(CurrentLine);
				}
				FileRead.Close();
			}
			else
			{
				ListBox2.Items.Add("Please select a file first");
			}
		}
