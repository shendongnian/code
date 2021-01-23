     Button btnDelete = new Button();
        btnDelete.Click += new EventHandler(button_Click);
        
        protected void button_Click (object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonid = button.ID.ToString()
            // identify which button was what row to update based on id clicked and perform necessary actions
        }
