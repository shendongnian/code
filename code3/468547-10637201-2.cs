    eg.EmailReceived += ag.NotifyEmail;
    tg.TweetPolled += ag.NotifyTweet;
    
    
    public class EventManager
    {
        public delegate void OnMailReceived(EMails m);
        public event MailReceived;
      
        ........
        private void GetMail()
        {
            EMails m;
            .....
            if(MailReceived != null) 
                MailReceived(m);
        }
    }
    public class AgentManager()
    {
         public void NotifyEMail(EMails m)
         {
             .....
         }
     
    }
   
