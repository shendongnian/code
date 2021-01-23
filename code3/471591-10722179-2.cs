    for (int i = 0; i <= count && i < 2; i++)
        {
            Button btnAdd = new Button();
            btnAdd.Text = dataTable.Rows[i]["deviceDescription"].ToString();
            btnAdd.Location = new Point(x, y);
            btnAdd.Tag = i;
            btnAdd.Name = "btn" + i.ToString();
            btnAdd.BackColor = Color.Green;
            this.Controls.Add(btnAdd);
            var temp = i;
            this.Controls[btnAdd.Name].MouseClick += (sender, e) =>
                {
                int index = temp;
                generalMethods.generatePopup(sender, e, index);
            };
    }
