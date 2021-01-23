      private void Form1_Load(object sender, EventArgs e)
        {
            var users = new List<User> { new User { UserName = "Jobert", Selected = false }, new User { UserName = "John", Selected = true }, new User { UserName = "Leah", Selected = true }, new User { UserName = "Anna", Selected = false } };
            dataGridView1.DataSource = users;
        }
