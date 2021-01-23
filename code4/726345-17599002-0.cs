    namespace WPFTesting
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            ObservableCollection<Message> messages = new ObservableCollection<Message>();
    
            public MainWindow()
            {
                InitializeComponent();
                messages.Add(new Message(DateTime.Now, "This is a test."));
                messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
                messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
                messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message.")); 
                ListView listView = new ListView();
                Style style = new Style();
                style.TargetType = typeof(ListViewItem);
                DataTrigger trigger = new DataTrigger();
                trigger.Binding = new Binding("Text");
                trigger.Value = "This is a test.";
                trigger.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Pink));
                style.Triggers.Add(trigger);
                style.Setters.Add(new Setter(ListViewItem.HeightProperty, 20.0));
                style.Setters.Add(new Setter(ListViewItem.MarginProperty, new Thickness(0)));
                style.Setters.Add(new Setter(ListViewItem.BorderThicknessProperty, new Thickness(0)));
                listView.ItemContainerStyle = style;
                GridView gridView = new GridView();
                listView.View = gridView;
                GridViewColumn timeStampColumn = new GridViewColumn();
                timeStampColumn.DisplayMemberBinding = new Binding("Date");
                GridViewColumnHeader timeStampHeader = new GridViewColumnHeader();
                timeStampHeader.Content = "Time";
                timeStampColumn.Header = timeStampHeader;
                gridView.Columns.Add(timeStampColumn);
                GridViewColumn messageColumn = CreateGridViewColumn("Message", "Text");
                gridView.Columns.Add(messageColumn);
                Binding binding = new Binding();
                binding.Source = messages;
                listView.SetBinding(ItemsControl.ItemsSourceProperty, binding);
                MainGrid.Children.Add(listView);
            }
    
            private static GridViewColumn CreateGridViewColumn(string header, string bindingPath)
            {
                GridViewColumn gridViewColumn = new GridViewColumn();
                gridViewColumn.Header = new GridViewColumnHeader() { Content = header };
                string xaml = @"
                <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""> 
                  <StackPanel Orientation=""Horizontal"">
                    <TextBlock Text=""{Binding Text}"" MaxHeight=""20"">
                      <TextBlock.ToolTip>
                        <TextBlock Text=""{Binding Text}""/>
                      </TextBlock.ToolTip>
                    </TextBlock>
                    <TextBlock Text="" -- ""/>
                    <TextBlock Text=""{Binding Date}""/>
                  </StackPanel>
                </DataTemplate>";
                StringReader stringReader = new StringReader(xaml);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                gridViewColumn.CellTemplate = XamlReader.Load(xmlReader) as DataTemplate;
    
                return gridViewColumn;
            }
    
            public class Message
            {
    
                public Message(DateTime aDate, String aText)
                {
                    Date = aDate;
                    Text = aText;
                }
    
                public DateTime Date { get; set; }
                public String Text { get; set; }
            }
        }
    }
