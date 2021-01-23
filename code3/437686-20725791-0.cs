        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
        switch (e.Button)
            {
                case MouseButtons.Right:
                {
                    rightClickMenuStrip.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                }
                break;
            }
        }
