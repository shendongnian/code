    private void VerticalButtonTextEvent(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            Graphics g = e.Graphics;
            g.FillRectangle(SystemBrushes.Control, button.ClientRectangle);
            using (Font f = new Font("Times New Roman", 8))
            {
                SizeF szF = g.MeasureString(button.Text, f);
                g.TranslateTransform(
                    (float) ((Button) sender).ClientRectangle.Width/(float) 2 + szF.Height/(float) 2,
                    (float) ((Button) sender).ClientRectangle.Height/(float) 2 -
                    (float) szF.Width/(float) 2);
                g.RotateTransform(90);
                g.DrawString(button.Text, f, Brushes.Black, 0, 0);
            }
        }
