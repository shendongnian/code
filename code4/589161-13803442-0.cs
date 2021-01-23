    public class Form
    {
        private List<LibraryBook> _books = new List<LibraryBook>();
        protected void Handle_Form_Submit_whatever()
        {
            var book = new LibraryBook(...); // add all the stuff from the form inputs
            _books.Add(book);
         
        }
       protected void Some_other_Eventhandler()
       {
           //do stuff with _books
       }
    }
