		private void comboBox1_Validating(object sender, CancelEventArgs e)
		{
			if (comboBox1.SelectedItem == null)
			{
				IList list = comboBox1.DataSource as IList;
				if (list != null)
				{
					TargetGroup group = new TargetGroup(comboBox1.Text);
					list.Add(group);
					comboBox1.DataSource = null;
					comboBox1.DataSource = list;
					comboBox1.DisplayMember = "Caption";
					comboBox1.SelectedItem = group;
				}
			}
		}
