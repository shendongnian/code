     public class Form1
     {
        private List<LibraryBook> booklist = new List<LibraryBook>();
        private void Button_Click(....)
        {
                string titles;
                titles = titleTextBox.Text;
                LibraryBook book = new LibraryBook(titles, authors, publishers, years, numbers);
                booklist.Add(book);
                booksListBox.Items.Add(titles);
        }
      }
