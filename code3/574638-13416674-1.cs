    private void button1_Click(object sender, EventArgs e)
    {
        var message = MyMethod("Title", "Message");
        MessageBox.Show(message.Title, message.Message);
    }
    Message myMethod(string name, string title)
    {
        return new Message{Title = title, Message = name};             
    }
