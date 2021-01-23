    List<Message> msgList = new List<Message>();
    using (MessageEnumerator me = queue.GetMessageEnumerator2())
    {
      while (me.MoveNext(new TimeSpan(0, 0, 0)))
      {
         Message message = me.Current;
         msgList.Add(message)
      }
    }
