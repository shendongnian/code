     private void btnOkClicked(object sender, RoutedEventArgs e)
    {
        Book newBook = new Book()
        {
            Tytul = tbTytul.Text,
            Autor = tbAutor.Text,
            Cena = Int32.Parse(tbCena.Text),
            Przeczytane = tbPrzeczytane.Text
        };
        var dal = new HomeDAL(); // pass any initialization parameters if required for the DAL to self initialize.
        var newBookId = dal.CreateBook(newBook);
        // use some mechanism to show the newly created book id to the user or else redirect the user to the grid that shows the books sorted by creation date so that the book he created now will be shown as the first one.
    }   
