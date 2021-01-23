    public class ChatRoom
    {
        public string username;
        public string firstname;
        public string lastname;
        
        public ChatRoom(){}
        public ChatRoom(string username, string firstname, string lastname)
        {
             this.username = username;
             this.lastname = lastname;
             this.firstname = firstname;
        }
    }
    public StartChatResult StartChat(StartChatEntity sce)
    {
        //doing something else
        List<ChatRoom> list =
             (from q in ChatManager.GetChatRoomList()
              select new ChatRoom(q.username, q.firstname, q.lastname)).ToList();
        return new StartChatResult() { IsSuccess = true, ChatRooms = list };
    }
