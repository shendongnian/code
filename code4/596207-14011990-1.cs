    public interface ITicketHelper
    {
        void HelpThis(Ticket t);
        IList<Ticket> HelpThat();
    }
    public class TicketHelper : ITicketHelper
    {
        public static readonly ITicketHelper Instance = new TicketHelper();
        private TicketHelper()
        { ... }
        public void HelpThis(Ticket t)
        { ... }
        public IList<Ticket> HelpThat()
        { ... }
    }
