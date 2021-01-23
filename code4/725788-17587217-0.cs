        private void Form1_Load(object sender, EventArgs e)
        {
            Button button2 = new Button();
            //Load button in container
            //Loading events for control
            button2.Click += new EventHandler(button2_Click);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Do Something
        }
