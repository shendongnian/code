     private int beamMoving;
     private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.VSplit;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int beam0 = (int)tableLayoutPanel1.ColumnStyles[0].Width;
                int beam1 = (int)tableLayoutPanel1.ColumnStyles[0].Width + (int)tableLayoutPanel1.ColumnStyles[1].Width;
                int beam2 = (int)tableLayoutPanel1.ColumnStyles[0].Width + (int)tableLayoutPanel1.ColumnStyles[1].Width + (int)tableLayoutPanel1.ColumnStyles[2].Width;
                switch (beamMoving)
                {
                    case 0:
                        {
                            if (e.X > 0)
                            {
                                tableLayoutPanel1.ColumnStyles[0].Width = e.X;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (e.X - beam0 > 0)
                            {
                                tableLayoutPanel1.ColumnStyles[1].Width = e.X - beam0;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (e.X - beam1 > 0)
                            {
                                tableLayoutPanel1.ColumnStyles[2].Width = e.X - beam1;
                            }
                            break;
                        }
                }
            }
        }
        private void cursorToDefault(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            int beam0 = (int)tableLayoutPanel1.ColumnStyles[0].Width;
            int beam1 = (int)tableLayoutPanel1.ColumnStyles[0].Width + (int)tableLayoutPanel1.ColumnStyles[1].Width;
            int beam2 = (int)tableLayoutPanel1.ColumnStyles[0].Width + (int)tableLayoutPanel1.ColumnStyles[1].Width + (int)tableLayoutPanel1.ColumnStyles[2].Width;
            if (e.X + 20 > beam0 && e.X - 20 < beam1)
            {
                beamMoving = 0;
            }
            if (e.X + 20 > beam1 && e.X - 20 < beam2)
            {
                beamMoving = 1;
            }
            if (e.X + 20 > beam2 && e.X - 20 < tableLayoutPanel1.Width)
            {
                beamMoving = 2;
            }                    
        }
