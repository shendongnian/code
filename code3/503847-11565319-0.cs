    [HubName("hubtest")]
    public class HubTest : Hub
    {
        CmsContext db = new CmsContext();
        
        public void showdata()
        {
            Clients.clearlist();
            var faqs = from x in db.Faqs
                    select x;
            foreach (Faq faq in faqs)
            {
                Clients.add(faq.Question.ToString());
            }
        }
    }
