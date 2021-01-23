        void SomeMethod()
        {
            MenuItem item = new MenuItem("Test");
            item.Click += item_Click;
            //Then your code..
            MenuItem[] menuItems = new MenuItem[] { item /*Etc...*/ };
        }
        void item_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
        }
