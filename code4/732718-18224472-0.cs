    protected static int GetMessageCount(MessageQueue q)
        {
           //var _messageQueue = new MessageQueue(queueName, QueueAccessMode.Peek);
           //_messageQueue.Refresh();  //done to get the correct count as sometimes it sends 0
           // var x = _messageQueue.GetMessageEnumerator2();
          int iCount = q.GetAllMessages().Count(); 
          // while (x.MoveNext())
           // {
           //    iCount++;
           // }
            return iCount;
        }
