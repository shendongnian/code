    class User
    {
        public User(string username)
        {
            this.Username = username;
            this.RequestQueue = new Queue<string>();
        }
        
        public User(string username, string message)
            : base(username)
        {
            this.RequestQueue.Add(message);
        }
        public string Username { get; set; }
        public Queue<string> ReqeustQueue { get; private set; }
    }
    ///......................
    public class MyClass
    {
        public MyClass()
        {
            this.Users = new List<User>();
            this.UserQueue = new Queue<User>();
        }
        public List<User> Users; //List of users currently being processed
        public Queue<User> UserQueue; //List of order for which users should be processed
        public void OnMessageRecievedFromIrcChannel(string username, string request)
        {
            lock (this.UserQueue) //For threadsafety
            {
                for (int i = 0; i < this.Users.Count; i++) //Check if we have this user already on the list
                {
                    if (this.Users[i].Username == username)
                    {
                        //The user is in the user list. That means he has previously sent request that are awaiting to be processed.
                        //As such, we can safely add his new message at the end of HIS request list.
                        
                        this.Users[i].RequestQueue.Add(request); //Add users new message at the end of the list
                        return;
                    }
                }
                //User is not in the user list. Means it's his first request. Create him in the user list and add his message
                this.Users.Add(new User(username, request)); //Create the user and his message
                this.UserQueue.Add(this.Users[this.Users.length - 1]); //Add the user to the last of the precessing users.
            }
        }
        
        //**********************************
        
        public void WorkerTick()
        {
            //This tick runs every 400ms and processes next message to be sent.
            lock (this.UserQueue) //For threadsafety
            {
                var user = this.UserQueue.Pop() //Pop the next user to be processed.
                var message = user.RequestQueue.Pop() //Pop his request
                
                /////PROCESSING MESSAGE GOES HERE
                
                if (user.RequestQueue.Count > 0) //If user has more messages waiting to be processed
                {
                    this.UserQueue.Add(user); //Add him at the end of the userqueue
                }
                else
                {
                    this.Users.Remove(user); //User has no more messages, we can safely remove him from the user list
                }
            }
        }
    }
