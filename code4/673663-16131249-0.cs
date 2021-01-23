		protected void GridView1_PreRender(object sender, EventArgs e)
		{
			if (GridView1.Rows.Count == 0)
			{
				LabelGrid.Text = "No more cities.";
			}
		}
