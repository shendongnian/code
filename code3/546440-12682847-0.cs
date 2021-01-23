    void Main()
    {
    	var top100 = (from m in Messages where m.IsSent == false select m).Take(100); 	
    	foreach (var message in top100) { 
    		message.IsSent = true; 
    	}
    	var count = Messages.Count(x => x.IsSent); 
    	Console.WriteLine(count);
    }
    List<Message> Messages {
    	get {
    		if(_messagesList == null) {
    			_messagesList = new List<Message>();
    			for (int i = 0; i < 100; i++)
    				_messagesList.Add(new Message { IsSent = false });
    		}
    		return _messagesList;
    	}
    }
    List<Message> _messagesList;
    class Message {
    	public bool IsSent { get; set; }
    }
