    public class ChatInformation {
      public IEnumerable<ChatMessage> messages;
      public string chatLogPath;
    }
    ...
    var output = new ChatInformation {
      messages = ...,
      chatLogPath = "path_to_a_text_file.txt"
    };
    return json.Serialize(output);
