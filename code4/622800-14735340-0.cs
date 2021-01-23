    public bool CanExecute() {
      var messages = new List<string>();
      if (!Condition1) {
        messages.Add("Missing Condition1");
      }
      ...
      Messages = messages;
      return messages.Count == 0;
    }
    public IEnumerable<string> Messages { get; private set; }
