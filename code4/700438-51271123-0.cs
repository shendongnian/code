        private void FormRegion1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (controlX.BackColor.ToArgb() == System.Drawing.Color.FromArgb(255, 0, 0, 0).ToArgb())
            {
                controlX.ForeColor = System.Drawing.Color.White;
            }
            else if (controlX.BackColor.ToArgb() == System.Drawing.Color.FromArgb(255, 255, 255, 255).ToArgb())
            {
                controlX.ForeColor = System.Drawing.Color.DarkGray;
            }
        }
