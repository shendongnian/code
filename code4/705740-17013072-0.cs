        private void button1_Click(object sender, EventArgs e)
        {
            Button c = new Button();
            c.Location = new Point(10 , 40);
            c.Text = "novo";
            ButtonList.Add(c); // add to list as well 
            panel1.Controls.Add(c);       
        }
