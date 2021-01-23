        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (SplitContainer sc in this.tableLayoutPanel1.Controls.OfType<SplitContainer>())
            {
                Label title = MakeLabel("OneClick", new Point(10, 10));
                sc.Panel1.Controls.Add(title);
                Label title1 = MakeLabel("TwoClick", new Point(10, 10));
                sc.Panel2.Controls.Add(title1);
            }
        }
        private Label MakeLabel(string caption, Point position)
        {
            Label lbl = new Label();
            lbl.Text = caption;
            lbl.Location = position;
            lbl.Visible = true;
            return lbl;
        }
