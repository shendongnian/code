1. Declare a delegate 	
    public delegate void UpdateChatAreaCallback(string text);
2. Create a method that will update the textbox:
    public void UpdateChatArea(string text){textBlockChatArea.Text += text;}
3. Invoke the method:
    textBlockChatArea.Invoke(new UpdateChatAreaCallback(UpdateChatArea, "new text"));
