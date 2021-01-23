    ConcurrentQueuequeue = new ConcurrentQueue(); //can use a BlockingCollection too (as it's just a blocking ConcurrentQueue by default anyway)
    
    public void OnUserStartedGame(User joiningUser)
    {
       User waitingUser;
       if (this.gameQueue.TryDequeue(out waitingUser)) //if there's someone waiting, we'll get him
          this.MatchUsers(waitingUser, joiningUser);
       else
          this.QueueUser(joiningUser); //it doesn't matter if there's already someone in the queue by now because, well, we are using a queue and it will sort itself out.
    }
    
    private void QueueUser(User user)
    {
       this.gameQueue.Enqueue(user);
    }
    
    private void MatchUsers(User first, User second)
    {
       //not sure what you do here
    }
