    private void InitializeComponent()
      {
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.pictureBox1.Location = new System.Drawing.Point(35, 28);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(100, 50);
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
         this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
         pictureBox1.Image = Properties.Resources.confirmation;
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
         pictureBox1.Image = Properties.Resources.error;
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
         pictureBox1.Image = Properties.Resources.confirmation;
    }
