    public partial class MainWindow: Window
    {
      public MainWindow()
      {
        InitializeComponent();
    
        List<Author> list = new List<Author> 
        {
          new Author { Name = "X Y", Content = "blah" },
          new Author { Name = "W Z", Content = "blah blah" },
          new Author { Name = "N N", Content = "blah blah blah" },
          new Author { Name = "M M", Content = "blah blah blah blah" },
        };
        dataGrid1.AutoGenerateColumns = true;
        dataGrid1.ItemsSource = list;
      }
    }
    
    public class Author
    {
      public string Name { get; set; }
      public DateTime PostedDate { get; set; }
      public string ProjectTitle { get; set; }
      public string Content { get; set; }
      public string Link { get; set; }
    }
