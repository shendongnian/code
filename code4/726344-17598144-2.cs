    public class MSGviewModel
    {
    private ObservableCollection<Message> messages = new ObservableCollection<Message>();
    public ObservableCollection<Message> Messages
    {
      get { return messages; }
    }
    public MSGviewModel()
    {
      messages.Add(new Message(DateTime.Now, "This is a test."));
      messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
      messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
      messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message.")); 
    }
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
