        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Top = 200;
            pb.Left = 200;
            pb.BackColor = Color.Gray;
            pb.MouseMove += new MouseEventHandler(pb_MouseMove);
            this.Controls.Add(pb);
        }
        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PictureBox thisPB = (PictureBox)sender;
                thisPB.Left = e.X;
                thisPB.Top = e.Y;
            }
        }
