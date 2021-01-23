        private Dictionary<int, AutoResetEvent> m_Events = new ...;
        public void IssueOrders(List<OrderAction> actions)
        {
            foreach (var action in actions)
            {
                if (action is AddOrder)
                {
                    uint userId = apiTransactions.PlaceOrder((action as AddOrder).order);
                    // Attention: Race condition if PlaceOrder finishes                                         
                    // before the MRE is created and added to the dictionary!
                    m_Events[userId] = new ManualResetEvent(false);
                    Console.WriteLine("order is placing userId = " + userId);
                }
                // TODO: implement other actions
            }
            WaitHandle.WaitAll(m_Events.Values);
            // TODO: Dispose the created MREs
        }
        private void OnApiTransactionsDataMessageReceived(object sender, DataMessageReceivedEventArgs e)
        {
            var dataMsg = e.message;
            var userId = dataMsg.UserId;
            m_Events[userId].Set();
        }
