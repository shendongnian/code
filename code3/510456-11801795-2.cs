    class User
    {
        public User(string username)
        {
            this.Username = username;
            this.RequestQueue = new Queue<string>();
        }
        
        private static readonly TimeSpan _minPostThreshold = new TimeSpan(0,0,5); //five seconds
        
        public void PostMessage(string message)
        {
            var lastMsgTime = _lastMessageTime;
            _lastMessageTime = DateTime.Now;
            if (lastMsgTime != default(DateTime))
            {
                if ((_lastMessageTime - lastMsgTime) < _minPostThreshold)
                {
                    return;
                }
            }
            _requestQueue.Enqueue(message);		
        }
        
        public string NextMessage
        {
            get
            {
                if (!HasMessages)
                {
                    return null;
                }
                
                return _requestQueue.Dequeue();
            }
        }
        
        public bool HasMessages
        {
            get{return _requestQueue.Count > 0;}
        }
        
        public string Username { get; set; }
        private Queue<string> _requestQueue { get; private set; }
        private DateTime _lastMessageTime;
    }
    class SendQueue
    {
        Timer tim;
        IRCBot host;
        public bool shouldRun = false;
        public Dictionary<string, User> Users;  //Dictionary of users currently being processed
        private Queue<User> _postQueue = new Queue<User>();
        
        public SendQueue(IRCBot launcher)
        {
            this.Users = new Dictionary<string, User>();
            this.tim = new Timer(WorkerTick, null, Timeout.Infinite, 450);
            this.host = launcher;
        }
        
        public void Add(string username, string request)
        {
            User targetUser;
            lock (Users) //For threadsafety
            {
                if (!Users.TryGetValue(username, out targetUser))
                {
                    //User is not in the user list. Means it's his first request. Create him in the user list and add his message
                    targetUser = new User(username);
                    Users.Add(username, targetUser); //Create the user and his message
                }
                
                targetUser.PostMessage(request);
            }
            
            lock(_postQueue)
            {
                _postQueue.Enqueue(targetUser);
            }
        }
        
        public void WorkerTick(object sender)
        {
            if (shouldRun)
            {
                User nextUser = null;
                
                lock(_postQueue)
                {
                    if (_postQueue.Count > 0)
                    {
                        nextUser = _PostQueue.Dequeue();
                    }
                }
                
                if (nextUser != null)
                {                
                    host.Say(nextUser.Username, nextUser.NextMessage);
                }
            }
        }
    }
