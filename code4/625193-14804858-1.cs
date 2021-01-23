    int x = 0;
    string[] images = Directory.GetFiles(@"C:\StackOverflow\New Folder");
    foreach (string image in images)
    {
        Panel item = new Panel();
        item.AutoSize = true;
        item.Location = new Point(x, 0);
        PictureBox PB = new PictureBox();
        PB.Image = new Bitmap(image);
        PB.SizeMode = PictureBoxSizeMode.CenterImage;
        PB.Size = new Size(250, 180);
        Label label1 = new Label();
        label1.Text = System.IO.Path.GetFileName(image);
        label1.Location = new Point(0, 90);
        label1.Width = 250;
        label1.TextAlign = ContentAlignment.MiddleCenter;
        item.Controls.Add(label1);
        item.Controls.Add(PB);
        panel1.Controls.Add(item);
        x += 260;
      
    }
