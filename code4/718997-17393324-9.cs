     public partial class ThreeColumnChatSample : Window
        {
            public ObservableCollection<ChatEntry> LogEntries { get; set; }
    
            private string TestData = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            private List<string> words;
            private int maxword;
            public Random random { get; set; }
    
            public ThreeColumnChatSample()
            {
                InitializeComponent();
    
                random = new Random();
                words = TestData.Split(' ').ToList();
                maxword = words.Count - 1;
    
                DataContext = LogEntries = new ObservableCollection<ChatEntry>();
                Enumerable.Range(0, 100)
                          .ToList()
                          .ForEach(x => LogEntries.Add(GetRandomEntry()));
            }
    
            private ChatEntry GetRandomEntry()
            {
                return new ChatEntry()
                    {
                        DateTime = DateTime.Now,
                        Sender = words[random.Next(0, maxword)],
                        Content = GetFlowDocumentString(string.Join(" ",Enumerable.Range(5, random.Next(10, 50)).Select(x => words[random.Next(0, maxword)])))
                    };
            }
    
            private string GetFlowDocumentString(string text)
            {
                return "<FlowDocument xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
                       "   <Paragraph>" +
                       "     <Run Text='" + text + "'/>" +
                       "   </Paragraph>" +
                       "</FlowDocument>";
            }
        }
