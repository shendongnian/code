    public class Word
    {
        public string english { get; set; }
        public string spanish { get; set; }
    }
    public partial class MainWindow : Window
    {
        public List<Word> MyDictionary {get; set;}
        public Word SelectedWord {get; set;}
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyDictionary = new List<Word>();
            Word word1 = new Word();
            word1.english = "Hello";
            word1.spanish = "Hola";
            Word word2 = new Word();
            word2.english = "Goodbye";
            word2.spanish = "Adios";
            Word word3 = new Word();
            word3.english = "How are you?";
            word3.spanish = "¿Qué tal?";
            MyDictionary.Add(word1);
            MyDictionary.Add(word2);
            MyDictionary.Add(word3);
            DataContext = this;
        }
        private void cmbBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("You have selected the word \"" + SelectedWord.spanish + "\"");
        }
    }
