    for (int f = 1; f <= 6; f++)
    {
        Dictionary<int, TextBox> dict = new Dictionary<int, TextBox>();
        dict.Add(f, new TextBox());
        dict[f].Location = new Point(0, f * 20);
        dict[f].Text = loto[f].ToString();
        this.Controls.Add(dict[f]);
    }
