        List<Label> lbls;
        private void create()
        {
            flowLayoutPanel1.Controls.Clear();
            //int length = ds.Tables[0].Rows.Count;
            lbls = new List<Labels>();
            for (int i = 0; i < 5; i++)
            {
                Label lbl = new Label();
                lbl.Name = i.ToString();
                lbl.Text = "Label "+i;
                lbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
                lbl.SetBounds(0, 20, 100, 25);
                lbl.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel1.Controls.Add(lbl);
                lbls.Add(lbl);
            }
        }
