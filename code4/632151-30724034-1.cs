            var c = sender as PictureBox;
            
            if (!_dragging || null == c) return;
            c.Top = e.Y + c.Top - _yPos;
            c.Left = e.X + c.Left - _xPos;
            foreach (Control d in picmap1.Controls)
                if (d is Label)
                {
                    d.Top = e.Y + d.Top - _yPos;
                    d.Left = e.X + d.Left - _xPos;
                }
        }
        private void picmap1_MouseUp_1(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (null == c) return;
            _dragging = false;
        }
        private void picmap1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
            foreach (Control d in picmap1.Controls)
                if (d is Label)
                {
                    _xPos = e.X;
                    _yPos = e.Y;
                }
        }
