        private static void HandleMessage(BattlEyeMessageEventArgs args) {
        //call a method to analyze data parse
            var oPlayerListEvent = new PlayerListEvent(args.Message);
            if (oPlayerListEvent.MessageIsValid()) {
                lock (m_cReceivedMessages)  {
                    m_cReceivedMessages.Add(oPlayerListEvent);
                }
            }
        }
