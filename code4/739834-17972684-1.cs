        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                control.Left += e.X - offset.X;
                control.Top += e.Y - offset.Y;
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            control.Left = ((control.Left + control.Width / 2) / control.Width) * control.Width;
            control.Top = ((control.Top + control.Height / 2) / control.Height) * control.Height;
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            offset = e.Location;
        }
