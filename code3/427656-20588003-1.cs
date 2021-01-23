        private Color cbBorderColor = Color.Gray;
        private Pen cbBorderPen = new Pen(SystemColors.Window);
        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {            
            foreach (ToolStripComboBox cb in toolStrip1.Items)
            {
                Rectangle r = new Rectangle(
                    cb.ComboBox.Location.X - 1,
                    cb.ComboBox.Location.Y - 1,
                    cb.ComboBox.Size.Width + 1,
                    cb.ComboBox.Size.Height + 1);
                cbBorderPen.Color = cbBorderColor;
                e.Graphics.DrawRectangle(cbBorderPen, r);
            }
        }
