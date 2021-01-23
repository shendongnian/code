    for (int i = 0; i < 10; i++)
    {
        CheckBox box = new CheckBox();
        box.Tag = i.ToString();
        box.Text = "a";
        box.AutoSize = true;
        box.Location = new Point(10, i * 50);
        this.Controls.Add(box);
    }
