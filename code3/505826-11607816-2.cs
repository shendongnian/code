    Dictionary<string, int> counts = new Dictionary<string, int>();
    foreach (string code in myCodeList)
    {
        if (!counts.ContainsKey(code))
        {
           counts.Add(code, 1);
        }
        else
        {
           counts[code]++;
        }
    }
     
    Point p = new Point(12, 12); //initial location - adjust it suitably
    foreach (var item in counts)
    {
        var label = new Label();
        label.Text = item.Key + " - " + item.Value;
        label.Location = new Point(p.X, p.Y);
        label.Tag = item; //optional
        Controls.Add(label);
        p.Y += label.Height + 6; //to align vertically
        //p.X += label.Width + 18; //to align horizontally. 
    }
