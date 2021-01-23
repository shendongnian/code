        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                control.Left = ((e.X + control.Left) / control.Width) * control.Width;
                control.Top = ((e.Y + control.Top) / control.Height) * control.Height;
            }
        }
