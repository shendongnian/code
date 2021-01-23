        private static readonly int SEARCH_BUTTON_WIDTH = 25;
        private void ConfigureSearchBox()
        {
            var btn = new Button();
            btn.Size = new Size(SEARCH_BUTTON_WIDTH, searchBox.ClientSize.Height + 2);
            btn.Location = new Point(searchBox.ClientSize.Width - btn.Width, -1);
            btn.Cursor = Cursors.Default;
            btn.Image = Properties.Resources.Find_5650;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += btn_Click;
            searchBox.Controls.Add(btn);
            this.AcceptButton = btn;
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(searchBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello world");
        }
