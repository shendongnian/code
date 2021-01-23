    public class Ticket : INotifyPropertyChanged
    {
        private List<TicketLine> ticketLines;
        public IEnumerable<TicketLine> TicketLines
        {
            get { return ticketLines.AsReadOnly(); }
        }
        public void Add(TicketLine ticketLine)
        {
            ticketLines.Add(ticketLine);
            OnPropertyChanged("TicketLines");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
