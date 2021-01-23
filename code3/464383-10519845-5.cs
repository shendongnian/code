    public class example
    {
        ChatForm chat;
        public example()
        {
             //you could also put this here
             //chat = new ChatForm(this);
        }
    
        public do()
        {
            if(chat == null)
                chat = new ChatForm(this); //or put this in the constructor
            chat.Show();
        }
    }
