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
		protected void Btn_Load_Click(object sender, EventArgs e)
		{
			DirectoryInfo dinfo = new DirectoryInfo(@"C:\errorlog");
			FileInfo[] Files = dinfo.GetFiles("*.txt");
			foreach (FileInfo file in Files)
			{
				ListBox1.Items.Add(file.FullName);
			}
		}
}
