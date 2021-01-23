    public class ThirdPartyFactory : IThirdPartyFactory
    {
        IThirdParty serviceA;
        IThirdParty serviceB;
        public ThirdPartyFactory(IThirdParty serviceA, IThirdParty serviceB)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
        }
        public IThirdParty GetThirdPartyService(ThirdParty thirdParty)
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
