    public class Helper
    {
        protected IList<Client> clients;
        protected IList<State> states;
    
        public Client GetClient(Guid id)
        {
            return clients.Where(c => c.Id == id);
        }
    
        public State GetState(short id)
        {
            return states.Where(s => s.Id == id);
        }
    }
