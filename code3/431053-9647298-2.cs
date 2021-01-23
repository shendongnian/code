    var images = new SortedList<string, Image>();
    images.Add("baseball_bat", Properties.Resources.baseball_bat);
    images.Add("bracelet", Properties.Resources.bracelet);
    ...
    
    // when you show the first image...
    pictureBox1.Image = images.Values[0];
    textBox1.Text = images.Keys[0];
    // when you show the nth image...
    pictureBox1.Image = images.Values[n];
    textBox1.Text = images.Keys[n];
