    public void IssueOrders(List<OrderAction> actions)
    {
        foreach (var action in actions)
        {
            if (action is AddOrder)
            {
                uint userId = apiTransactions.PlaceOrder((action as AddOrder).order);
                Console.WriteLine("order is placing userId = " + userId);
                lock(theHashMap)
                   theHashMap[userId] = "blargh";
            }
            // TODO: implement other actions
        }
        // how to wait until OnApiTransactionsDataMessageReceived for all userId is received?
        do
        {
           lock(theHashMap)
              if(theHashMap.Count == 0)
                 break;
           Thread.Sleep(125);
        }while(true);
        // now you have the guarantee that all were received
    }
    private Dictionary<int, string> theHashMap = new Dictionary<int,string>();
    private void OnApiTransactionsDataMessageReceived(object sender, DataMessageReceivedEventArgs e)
    {
        var dataMsg = e.message;
        var userId = dataMsg.UserId;
        // do some other things
        lock(theHashMap)
            theHashMap.Remove(userId);
    }
