        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging && c != null)
            {
                int maxX = pictureBox1.Size.Width * -1 + panel.Size.Width;
                int maxY = pictureBox1.Size.Height * -1 + panel.Size.Height;
                int newposLeft = e.X + c.Left - xPos;
                int newposTop = e.Y + c.Top - yPos;
                if (newposTop > 0)
                {
                    newposTop = 0;
                }
                if (newposLeft > 0)
                {
                    newposLeft = 0;
                }
                if (newposLeft < maxX)
                {
                    newposLeft = maxX;
                }
                if (newposTop < maxY)
                {
                    newposTop = maxY;
                }
                c.Top = newposTop;
                c.Left = newposLeft;
            }
        }
