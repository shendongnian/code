    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtIsbn.Text == "" || txtArtist.Text == "")
        {
           MessageBox.Show("Please fill in both Artist Name and Number of Members");
           return;
        }
        Book book = new Book(txtArtist.Text, txtIsbn.Text);
        if (music.ContainsKey(book.Artist))
        {
            MessageBox.Show("Already Exist!!");
            return;
        }
        music.Add(book.Artist, book);
        var books = music.Values.ToList();   
        listBox1.DisplayMember = "Artist"; // set it in designer
        listBox1.DataSource = books;
        listBox3.DisplayMember = "MEM"; // set it in designer
        listBox3.DataSource = books;
    }
