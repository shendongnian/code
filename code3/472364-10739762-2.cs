    private void make_BookButtonAndStore(int x, int y, string name)
    {
        make_Book(x,y,name);
        Properties.Settings.Default.ButtonStringCollection.Add(String.Format("{0};{1};{2}", book1.Location.X, book1.Location.Y, book1.Name));
        Properties.Settings.Default.Save();
    }
    private void make_Book(int x, int y, string name)
    {
        // this code is initializing the book(button)
        Button book1 = new Button();
        Image img = button1.Image;
        book1.Image = img;
        book1.Name = name;
        book1.Height = img.Height;
        book1.Width = img.Width;
        book1.Location = new Point(44 + x, 19 + y);            
        book1.Click += new EventHandler(myClickHandler);
        groupBox1.Controls.Add(book1);
    }
