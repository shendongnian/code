        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(TextBox1.Text); i++)
            {
                Button bt = new Button();
                bt.Text = "ok" + i.ToString();
                bt.Location = new Point(20, 30 * i);
                bt.Click += new EventHandler(bt_click);
                this.Controls.Add(bt);
            }
        }
        protected void bt_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Label1.Text = btn.Text + " Clicked";
        }
