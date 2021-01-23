		private void Populate(object sender, EventArgs e)
		{	
			listView1.Items.Add("D");
			listView1.Items.Add("B");
			listView1.Items.Add("A");
			listView1.Items.Add("C");
		}
		private void SelectFirst(object sender, EventArgs e)
		{
			listView1.Items[0].Selected = true;
			listView1.Select();
		}
		private void SortAndSelect(object sender, EventArgs e)
		{
			listView1.Sorting = SortOrder.Ascending;
			listView1.Sort();
			listView1.Items[0].Selected = true;
			listView1.Select();
		}
