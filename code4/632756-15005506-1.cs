    CheckBox box;
    for (int i = 0; i < 10; i++)
    {
        box = new CheckBox();
        box.Tag = i.ToString();
        box.Text = "a";
        box.AutoSize = true;
        box.Location = new Point(10, i * 50); //vertical
        //box.Location = new Point(i * 50, 10); //horizontal
        this.Controls.Add(box);
    }
