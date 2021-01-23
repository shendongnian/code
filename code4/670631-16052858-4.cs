    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var fc = new List<FilterChars>();
            var dbBooks = new List<Book>();
            var books = dbBooks
            .Where((book) =>
            {
            foreach (var filterChar in fc)
            {
                if (!book.BookCharacteristic.Contains(new BookCharacteristic() { CharacteristicID = filterChar.CharID, Value = filterChar.CharVal },
                                                        new BookCharacteristicEqualityComparer()))
                    return false;
            }
            return true;
            });
        }
      
    }
    public class FilterVM
    {
        public string ContentRating { get; set; }
        public List<FilterChars> FilterChars { get; set; }
    }
    public class FilterChars
    {
        public int CharID { get; set; }
        public int CharVal { get; set; }
    }
    public class Book
    {
        public int BookID { get; set; }
        public ICollection<BookCharacteristic> BookCharacteristic { get; set; }
    }
    public class BookCharacteristic
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int CharacteristicID { get; set; }
        public Book Book { get; set; }
        public int Value { get; set; }
    }
    public class BookCharacteristicEqualityComparer : IEqualityComparer<BookCharacteristic>
    {
        public bool Equals(BookCharacteristic x, BookCharacteristic y)
        {
            return x.CharacteristicID == y.CharacteristicID && x.Value == y.Value;
        }
        public int GetHashCode(BookCharacteristic obj)
        {
            return obj.CharacteristicID * obj.Value;
        }
    }
