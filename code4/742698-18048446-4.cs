        private int _oldNUDvalue = 0; //or assign it to the default value
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int delta = (int)numericUpDown1.Value - _oldNUDvalue;
            if (delta < 0)
            {
                for (int i = -delta; i > 0; i--)
                {
                    var tbox = Controls.Find("ntextBox" + (_oldNUDvalue - i), false)[0];
                    Controls.Remove(tbox);
                }
            }
            else if (delta > 0)
            {
                for (int i = _oldNUDvalue; i < _oldNUDvalue + delta; i++)
                {
                    var tbox = new TextBox();
                    tbox.Location = new Point(15, 55 + (30 * i));
                    tbox.Name = "ntextBox" + i;
                    Controls.Add(tbox);
                }
            }
            _oldNUDvalue = (int)numericUpDown1.Value;
        }
