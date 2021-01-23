    public class ThirdPartyFactory : IThirdPartyFactory
    {
        public ThirdPartyFactory(IThirdParty serviceA, IThirdParty serviceB)
        {
            this.serviceA = serviceA;
            this.serviceB = serviceB;
        }
        IThirdParty serviceA;
        IThirdParty serviceB;
    
        public void SendIncident(Ticket objectToBeSent)
        {
            IThirdParty thirdPartyService = GetThirdPartyService(objectToBeSent.ThirdPartyId);
            thirdPartyService.SendIncident(objectToBeSent);
        }
    
        private IThirdParty GetThirdPartyService(ThirdParty thirdParty)
        {
            switch (thirdParty)
            {
                case ThirdParty.AAA:
                    return serviceA;
    
                default:
                    return serviceB;
            }
        }
    }
