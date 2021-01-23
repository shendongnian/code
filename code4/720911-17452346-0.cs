        public void createLinks(string[] groupNames)
        {
            for (int i = 0; i < groupNames.Length; i++)
            {
                LinkLabel obj = new LinkLabel();
                obj.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                obj.LinkColor = Color.Black;
                obj.Name = groupNames[i];
                obj.Text = groupNames[i];
                obj.Click += delegate(object sender, EventArgs e)
                {
                    LinkLabel ss = sender as LinkLabel; 
                    frmCompanyReport test = new frmCompanyReport(ss.Name);
                    test.Show();
                };
                flowLayoutPanel1.Controls.Add(obj);
                
                Label line = new Label();
                line.AutoSize = false;
                line.BorderStyle = BorderStyle.FixedSingle;
                line.Height = 1;
                line.Width = flowLayoutPanel1.Width;
                flowLayoutPanel1.Controls.Add(line);
            }
        }
