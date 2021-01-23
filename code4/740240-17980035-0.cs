    foreach (var listBoxItem in listBox1.Items)
    {
        Label LB = new Label();
        LB.Name = "Label" + listBoxItem.ToString();
        LB.Location = new Point(257, (51 * lbl) + 25);
        LB.Size = new Size(500, 13);
        LB.Text = listBoxItem.ToString();
        LB.Click += new EventHandler(LB_Click); //assign click handler
        Controls.Add(LB);
        lbl++;
    }
