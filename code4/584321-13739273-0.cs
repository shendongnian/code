            private BookVO AddNewBook()
        {
            BookVO bookToAdd = new BookVO()
            {
                Author = txtBxBookAuthor.Text,
                Discount = double.Parse(txtBxBookDiscount.Text),
                Genre = txtBxBookGenre.Text,
                ISBN = txtBxBookISBN.Text,
                Name = txtBxBookName.Text,
                Price = double.Parse(txtBxBookPrice.Text),
                Publisher = txtBxBookPublisher.Text,
                ReleaseDate = DateTime.Parse(dateTimeBookPicker.Text)
            };
            return bookToAdd;
