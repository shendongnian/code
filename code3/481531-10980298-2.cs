    // Each row returned from the database will be converted in to one of these.
         public class ChatEntry
            {
                public string UserName { get; set; }
                public string Message { get; set; }
                public int MessageID { get; set; }
            }
    
    // You will need to introduce a MessageID field to your database to make this method work.
        public partial class MainWindow : Window
        {
            public ObservableCollection<ChatEntry> Entries
            {
                get { return (ObservableCollection<ChatEntry>)GetValue(EntriesProperty); }
                set { SetValue(EntriesProperty, value); }
            }
    
            public static readonly DependencyProperty EntriesProperty = DependencyProperty.Register("Entries", typeof(ObservableCollection<ChatEntry>), typeof(MainWindow), new UIPropertyMetadata(null));
    
            // This will be used to make sure that only new entries are added to the chat log.
            int lastMessageID;
    
            // This will be used to call UpdateEntries every second.
            Thread updateThread;
    
            public MainWindow()
            {
                Entries = new ObservableCollection<ChatEntry>();
    
                InitializeComponent();
    
                updateThread = new Thread(new ThreadStart(UpdateEntries));
                updateThread.Start();
            }
    
            void UpdateEntries()
            {
                while (true)
                {
    
                    // Prepare your query to gather messages from the message table
                    // with MessageID > lastMessageID.
    
                    // This bit needs to be done on the UI dispatcher or it'll cause an exception.
                    this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            // Each row that came back is a new message and can be added to the collection.
                            foreach (var row in rows)
                            {
                                Entries.Add(new ChatEntry()
                                {
                                    UserName = (string)row["UserName"],
                                    Message = (string)row["Message"],
                                });
                            }
                        }));
    
                    // at this point, the UI will have been upadted with JUST the new entries, no flicker
                    // no scrolling to the top each second.
    
                    // just one more thing, we need to set lastMessageID to be the latest messageID 
                    // so next time UpdateEntries is called it'll only get the new ones that we don't 
                    // have yet.
                    lastMessageID = Entries.Max(x => x.MessageID);
    
                    // Sleep for a second to ease the update speed.
                    Thread.Sleep(1000);
                }
            }
        }
   
