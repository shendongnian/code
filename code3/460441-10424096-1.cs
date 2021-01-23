    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<Page> book = new List<Page>();
            int pageNumber = -2;
            public MainWindow()
            {
                InitializeComponent();
    
                for(int i=1; i<10; i++)
                    book.Add(new Page("This is page number "+i+"\n\nContent goes in here."));
    
                // open the book on first page
                button1_Click(null, null);
               
            }
    
            class Page
            {
                public Page(string text)
                {
                    this.Text = text;
                }
                public string Text { get; set; }
            }
    
    
            public void setTextToPage(ref RichTextBox page, string text)
            {
                // Create a FlowDocument to contain content for the RichTextBox.
                FlowDocument myFlowDoc = new FlowDocument();
    
                // Add paragraphs to the FlowDocument.
                myFlowDoc.Blocks.Add(new Paragraph(new Run(text)));
    
                page.Document = myFlowDoc;
    
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                if (book.Count < (pageNumber + 4))
                {
                    return;
                }
    
                pageNumber += 2;
                setTextToPage(ref richTextBox1, book[pageNumber].Text);
                setTextToPage(ref richTextBox2, book[pageNumber+1].Text);
                
            }
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                if (pageNumber < 2)
                    return;
    
                pageNumber -= 2;
                setTextToPage(ref richTextBox1, book[pageNumber].Text);
                setTextToPage(ref richTextBox2, book[pageNumber + 1].Text);
            }
        }
    }
