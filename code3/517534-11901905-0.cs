    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        List<Book> books = new List<Book>();
        books.Add(new Book { bookID = 1, bookName = "Test-Driven Development (Kent Beck)" });
        books.Add(new Book { bookID = 2, bookName = "Refactoring (Martin Fowler)" });
        books.Add(new Book { bookID = 3, bookName = "Code Complete: 2nd Edition (Steve McConnell)" });
        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
        c.DataSource = books;
        c.Value = 1;
        c.ValueMember = "bookID";
        c.DisplayMember = "bookName";
        dataGridView1.Rows[0].Cells[0] = c;
    }
