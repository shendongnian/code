        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < 20; x++)
                {
                    label[x] = new Label { Name = x.ToString("00"), BackColor = Color.Blue, Text = "Test" };
                    panel[x] = new Panel { Name = x.ToString("00"), BackColor = Color.Blue };
                }
                this.Controls.AddRange(label);
                this.Controls.AddRange(panel);
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }
