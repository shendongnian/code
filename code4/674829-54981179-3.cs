        internal IHubProxy RoomHub;
        public static SignalRUtility Instance
        {
            get
            {
                if (_instance == null)
                {
                    Host = ConfigurationManager.AppSettings["signalRHost"];
                    _instance = new SignalRUtility();
                }
                return _instance;
            }
        }
        private SignalRUtility()
        {
            Connection = new HubConnection(Host + "/signalr", useDefaultUrl: false);
            PublicHub = Connection.CreateHubProxy("PublicHub");
            RoomHub = Connection.CreateHubProxy("RoomStatusHub");
            RoomHub.On<string>("UpdateRoomStatus", (code) =>
            {
                if(RoomStatusDelegates != null)
                {
                    RoomStatusDelegates(code);
                }
            });
            RoomHub.On<string>("UpdateOrderStatus", (code) =>
            {
                if (OrderStatusDelegates != null)
                {
                    OrderStatusDelegates(code);
                }
            });
            Connection.Start().Wait();
        }
