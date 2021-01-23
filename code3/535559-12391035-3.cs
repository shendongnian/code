    [Component]
    public class ReplyEmailNotification : ISubscriberOf<ReplyPosted>
    {
        ISmtpClient _client;
        IUserQueries _userQueries;
        
        public ReplyEmailNotification(ISmtpClient client, IUserQueries userQueries)
        {
            _client = client;
            _userQueries = userQueries;
        }
        
        public void Invoke(ReplyPosted e)
        {
            var user = _userQueries.Get(e.PosterId);
            _client.Send(new MailMessage(user.Email, "bla bla"));
        }
    } 
