    public class PartnerController : ApiController
    {
        public Partner Get(string id)
        {
            ...
        }
        public IEnumerable<string> GetVoucherTypesForPartner(string partnerId)
        {
            ...
        }
    }
