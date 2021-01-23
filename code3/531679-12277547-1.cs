    public void IssueOrders(List<OrderAction> actions)
    {
        var userIds = new List<uint>();
        lock(theHashMap)
            theHashMap[userIds] = "blargh";
        foreach (var action in actions)
        {
            if (action is AddOrder)
            {
                lock(userIds)
                {
                   uint userId = apiTransactions.PlaceOrder((action as AddOrder).order);
                   Console.WriteLine("order is placing userId = " + userId);
                   userIds.Add(userId);
                }
            }
            // TODO: implement other actions
        }
        // waiting:
        do
        {
           lock(userIds)
              if(userIds.Count == 0)
                 break;
           Thread.Sleep(???); // adjust the time depending on how long you wait for a callback on average
        }while(true);
        lock(theHashMap)
            theHashMap.Remove(userIds);
        // now you have the guarantee that all were received
    }
    private Dictionary<List<uint>, string> theHashMap = new Dictionary<List<uint>,string>();
    private void OnApiTransactionsDataMessageReceived(object sender, DataMessageReceivedEventArgs e)
    {
        var dataMsg = e.message;
        var userId = dataMsg.UserId;
        // do some other things
        lock(theHashMap)
            foreach(var list in theHashMap.Keys)
               lock(list)
                  if(list.Remove(userId))
                     break;
    }
