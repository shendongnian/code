    public class Message {
      public string Text { get; set; }
      public ICommand Command { get; set; }
    }
    ...
    public bool CanExecute() {
      var messages = new List<Message>();
      if (!Condition1) {
        messages.Add(
          new Message { 
            Text = "Missing Condition1", 
            Command = new FixCondition1Command() 
          }
        );
      }
      ...
      Messages = messages;
      return messages.Count == 0;
    }
    public IEnumerable<Message> Messages { get; private set; }
