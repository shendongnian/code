      public class Sent
    {
        public int MsgID;
        public string Content;
        public int Status;
        
    }
    public class Messages
    {
        public int MsgID;
        public string Content;
    }
      List<Sent> SentList = new List<Sent>() { new Sent() { MsgID = 1, Content = "aaa", Status = 0 }, new Sent() { MsgID = 3, Content = "ccc", Status = 0 } };
                List<Messages> MsgList = new List<Messages>() { new Messages() { MsgID = 1, Content = "aaa" }, new Messages() { MsgID = 2, Content = "bbb" }, new Messages() { MsgID = 3, Content = "ccc" }, new Messages() { MsgID = 4, Content = "ddd" }, new Messages() { MsgID = 5, Content = "eee" }};
                int [] sentMsgIDs = SentList.Select(v => v.MsgID).ToArray();
                List<Messages> result1 = MsgList.Where(o => !sentMsgIDs.Contains(o.MsgID)).ToList<Messages>();
