    [HubName("hubtest")]
    public class HubTest : Hub
    {
        TestDatabaseEntities db = new TestDatabaseEntities();
    
        public void showdata()
        {
            var f = from x in db.FAQs
                    select x;
    
            Clients.add(f);
        }
    }
