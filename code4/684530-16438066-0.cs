        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labels.Clear();
            Control[] matches;
            for (int i = 1; i <= 16; i++)
            {
                matches = this.Controls.Find("label" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is Label)
                {
                    Label lbl = (Label)matches[0];
                    labels.Add(lbl);
                    lbl.Enabled = true;
                    if (lbl.Visible == false)
                    {
                        lbl.Visible = true;
                    }
                }
            }
        }
