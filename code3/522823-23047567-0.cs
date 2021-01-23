    DateTime t = DateTime.Now;
    while (i < image1.Length) {
        DateTime now = DateTime.Now;
        if ((now - t).TotalSeconds >= 2) {
            pictureBox1.Image = Image.FromFile(image1[i]);
            i++;
            t = now;
        }
        Application.DoEvents();
    }
