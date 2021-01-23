    [Serializable]
    public class User
    {
          public string FriendlyName { get; set; }
    }
    
    [Serializable]
    public class Message
    {
          public string Text { get; set; }
          public DateTime DateTime { get; set; }
          public int SessionID { get; set; }
          public User Form { get; set; }
          public User To { get; set; }
    }
