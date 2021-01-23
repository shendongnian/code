    // where does this i come from here?
    author[i].Name = textBoxAddAuthor.Text;                       // this is useless..
    author[i].YrOfPub = textBoxYrOfPub.Text;                      // this is useless..
    author[i] = new Author(author[i].Name, author[i].YrOfPub);    // overwriting author[i] here
    Array.Sort(author);            // why are you sorting the array each time you insert?
    authorAVL.InsertItem(artist[i]);
