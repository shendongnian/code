    [ComVisible(true)]
    public class MyRootClass : IMyRootClass // some class to start with
    {
        public IEmailEntity[] GetEntities()
        {
            List<IEmailEntity> list = new List<IEmailEntity>();
            for(int i = 0; i < 10; i++)
            {
                EmailEntity entity = new EmailEntity();
                List<IEmailAddress> addresses = new List<IEmailAddress>();
                addresses.Add(new EmailAddress { Name = "Joe" + i });
                entity.BccRecipients = addresses.ToArray();
                entity.Body = "hello world " + i;
                list.Add(entity);
            }
            return list.ToArray();
        }   
    }
    [ComVisible(true)]
    public interface IMyRootClass
    {
        IEmailEntity[] GetEntities();
    }
    public class EmailEntity : IEmailEntity
    {
        public IEmailAddress[] BccRecipients { get; set; }
        public string Body { get; set; }
    }
    public class EmailAddress : IEmailAddress
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }
    [ComVisible(true)]
    public interface IEmailAddress
    {
        string Address { get; set; }
        string Name { get; set; }
    }
    [ComVisible(true)]
    public interface IEmailEntity
    {
        IEmailAddress[] BccRecipients { get; set; }
        string Body { get; set; }
        // to be continued...
    }
