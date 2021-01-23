    private void CreateButtons(object sender, EventArgs e)
        {
            for (int i = 0; 8 < length; i++)
            {
                for (int j = 0; 8 < length; i++)
                {
                    var btn = new Button() { Text = "Something" };
                    btn.Click += new EventHandler(btn_Click);
                    this.tableLayoutPanel1.Controls.Add(btn, i, j);
                }
            }
            
        }
        void btn_Click(object sender, EventArgs e)
        {
             ((Button)sender).Image= SomeMethodThatReturnsAnImage();
        }
