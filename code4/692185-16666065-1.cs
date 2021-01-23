    string dir = "";
            if (input.Text.Contains(@"\\"))
            {
                dir += @"\\";
            }
            string[] folders = input.Text.Split(new char[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string folder in folders)
            {
                if (dir.Contains(@"\\") && folder == folders[0])
                {
                    dir += folder + @"\";
                }
                else
                {
                    dir += folder + @"\";
                    ResultGroup newbox = new ResultGroup(folder);
                    newbox.label1.Click += (x, y) =>
                    {
                        splitContainer1.Panel2Collapsed = false;
                        listBox1.Items.Add(newbox.label1.Text);
                    };
                    flowLayoutPanel1.Controls.Add(newbox);
                    DirectoryInfo di = new DirectoryInfo(dir);
                    DirectorySecurity ds = di.GetAccessControl();
                    foreach (AccessRule rule in ds.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        newbox.listBox1.Items.Add(string.Format("{0}", rule.IdentityReference.Value));
                    }
                }
            }
