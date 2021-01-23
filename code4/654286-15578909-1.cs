        private void button1_Click(object sender, EventArgs e)
        {
            var x = new Timer();
            x.Tick += new EventHandler((obj, eventargs) => {
                var t = obj as Timer;
                var tag = (int)t.Tag;
                label1.Text = string.Format("{0:0.0}s until shutdown", tag/10d);
                t.Tag = tag - 1;
                if (tag == 0)
                {
                    t.Enabled = false;
                    MessageBox.Show("I shall initiate the shutdown here!", "Brace yourself!");
                    Process.Start("shutdown", "/s /t 10"); // Do the actual shutdown here
                }
            });
            x.Interval = 100;
            x.Tag = 30;
            x.Enabled = true;
        }
