        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                Dictionary<Control, Tuple<Color, Color>> oldcolors = new Dictionary<Control, Tuple<Color, Color>>();
                foreach (Control ctl in this.Controls)
                {
                    oldcolors.Add(ctl, Tuple.Create(ctl.BackColor, ctl.ForeColor));
                    // get rough avg intensity of color
                    int bg = (ctl.BackColor.R + ctl.BackColor.G + ctl.BackColor.B) / 3;
                    int fg = (ctl.ForeColor.R + ctl.ForeColor.G + ctl.ForeColor.B) / 3;
                    ctl.BackColor = Color.FromArgb(bg, bg, bg);
                    ctl.ForeColor = Color.FromArgb(fg, fg, fg);
                }
                dialog.ShowDialog();
                foreach (Control ctl in this.Controls)
                {
                    ctl.BackColor = oldcolors[ctl].Item1;
                    ctl.ForeColor = oldcolors[ctl].Item2;
                }
            }
        }
