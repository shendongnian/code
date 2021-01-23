    for (int i = 1; i < 5; i++)
    {
        var panel1 = new Panel() { Size = new Size(90, 80), Location = new Point(10, i * 100), BorderStyle = BorderStyle.FixedSingle };
        panel1.Controls.Add(new Label() { Text = i.ToString(), Location = new Point(10, 20) });
        panel1.Controls.Add(new Label() { Text = i.ToString(), Location = new Point(10, 40) });
        panel1.Controls.Add(new Label() { Text = i.ToString(), Location = new Point(10, 60) });
        Controls.Add(panel1);
    }
