    using Word = Microsoft.Office.Interop.Word;
    namespace TestApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                Word.Application oWord = new Word.Application();
                oWord.Visible = true;
            }
        }
    }
