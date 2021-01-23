	private async void button3_Click(object sender, EventArgs e)
	{
		try
		{
			var list = await GetSomething();
			foreach (int i in list)
			{
				listView1.Items.Add(new ListViewItem(i.ToString()));
			}
	
			Thread.Sleep(10000);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
