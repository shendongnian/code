    var images = new SortedList<string, Image>();
    images.Add("baseball_bat", Properties.Resources.baseball_bat);
    images.Add("bracelet", Properties.Resources.bracelet);
    ...
    
    pictureBox1.Image = images.Values[0];
    textBox1.Text = images.Keys[0];
