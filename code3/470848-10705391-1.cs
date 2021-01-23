    for (int i = 0; i <= count && i < 3; i++)
        {
            Button btnAdd = new Button();
            btnAdd.Name="btn"+i;
            btnAdd.Text = dataTable.Rows[i]["deviceDescription"].ToString();
            btnAdd.Location = new Point(x, y);
            btnAdd.Tag = i;
            this.Controls.Add(btnAdd);
        }
