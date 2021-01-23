    public class GetExpressCheckoutDetailsResponse : IPaypalResponse
    {
        public GetExpressCheckoutDetailsResponse(Dictionary<string, string> data)
        {
            this.Token = data["TOKEN"];
            this.BillingAgreementAcceptedStatus = data["BILLINGAGREEMENTACCEPTEDSTATUS"];
            ...
        }
    }
