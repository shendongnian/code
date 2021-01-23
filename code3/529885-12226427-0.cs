    class ListMessage<T> {
       private List<T> _messages;
       public IEnumerable<T> Messages { get { return _messages; } }
    
       public ListMessage (IEnumerable<T> messages) {
          this._messages = messages.ToList ();
       }
    }
