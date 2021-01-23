    public TicketSender
    {
        IThirdPartyFactory _factory
        public void TicketSender(IThirdPartyFactory factory)
        {
            _factory = factory;
        }
        public void SendIncident(Ticket ObjectToBeSent)
        {
             var service = _factory.GetThirdPartyService(ObjectToBeSent.ThirdPartyId);
             service.SendIncident(ObjectToBeSent);
        }
    }
