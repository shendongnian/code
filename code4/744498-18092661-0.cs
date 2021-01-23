	int right = 50;
	// Create Image + Text
	PictureBox pbox = new PictureBox();
	pbox.Size = new Size(140, 80);
	pbox.Location = new Point(right, 0);
	pbox.Image = Image.FromFile("");
	// Create label
	Label lblPlateNOBAR = new System.Windows.Forms.Label();
	lblPlateNOBAR.Text = lblPlateNO.Text;
	lblPlateNOBAR.Location = new Point(right + 20, 80);
	foreach(var control in Panel1.Controls)
	{
		control.Top = control.Top + 150;
	}
	Panel1.Controls.Add(pbox);
	Panel1.Controls.Add(lblPlateNOBAR);
