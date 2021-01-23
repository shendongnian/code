    private void Form1_KeyDown(object sender, KeyEventArgs e)
     {
        if (e.KeyCode == Keys.Space)
        {
          control = false;
          shootP = new PictureBox();
          shootP.Image = Properties.Resources.shoot_1;
          shootP.SizeMode = PictureBoxSizeMode.Zoom;
          shootP.Size = new Size(10, 72);
          ListShoot.Add(shootP);
          timeShoot.Start();
        }
     }
