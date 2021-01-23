        for (int i = 0; i < 40; i++)
        {
            CheckBox c = new CheckBox();
            c.Location = new Point(20 * i, 20);
            c.Width = 20;
            c.Text = i.ToString();
            this.Controls.Add(c);
        }
