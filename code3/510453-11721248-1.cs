    class User
    {
        public User(string username)
        {
            this.Username = username;
            this.RequestQueue = new Queue<string>();
        }
        public User(string username, string message)
            : this(username)
        {
            this.RequestQueue.Enqueue(message);
        }
        public string Username { get; set; }
        public Queue<string> RequestQueue { get; private set; }
    }
    ///......................
    public class MyClass
    {
        public MyClass()
        {
            this.Users = new Dictionary<string, User>();
            this.UserQueue = new Queue<User>();
        }
        public Dictionary<string, User> Users; //Dictionary of users currently being processed
        public Queue<User> UserQueue; //List of order for which users should be processed
        public void OnMessageRecievedFromIrcChannel(string username, string request)
        {
            lock (this.UserQueue) //For threadsafety
            {
                if (this.Users.ContainsKey(username))
                {
                    //The user is in the user list. That means he has previously sent request that are awaiting to be processed.
                    //As such, we can safely add his new message at the end of HIS request list.
                    this.Users[username].RequestQueue.Enqueue(request); //Add users new message at the end of the list
                    return;
                }
                //User is not in the user list. Means it's his first request. Create him in the user list and add his message
                var user = new User(username, request);
                this.Users.Add(username, user); //Create the user and his message
                this.UserQueue.Enqueue(user); //Add the user to the last of the precessing users.
            }
        }
        //**********************************
        public void WorkerTick()
        {
            //This tick runs every 400ms and processes next message to be sent.
            lock (this.UserQueue) //For threadsafety
            {
                var user = this.UserQueue.Dequeue(); //Pop the next user to be processed.
                var message = user.RequestQueue.Dequeue(); //Pop his request
                /////PROCESSING MESSAGE GOES HERE
                if (user.RequestQueue.Count > 0) //If user has more messages waiting to be processed
                {
                    this.UserQueue.Enqueue(user); //Add him at the end of the userqueue
                }
                else
                {
                    this.Users.Remove(user.Username); //User has no more messages, we can safely remove him from the user list
                }
            }
        }
    }
