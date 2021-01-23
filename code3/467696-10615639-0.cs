    public class ClassToTest
    {
        public IRepository Repository { get; private set; }
    
        public ClassToTest(IRepository repository)
        {
            Repository = repository;
        }
    
        public void CreateMyTicket(int ticketnumber, string name)
        {
            var t = new TicketObject(ticketnumber, name);
            t.Upgrade = ticketnumber + 2;
            Repository.Save(t);
        }
    }
