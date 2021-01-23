    class Paypal
    {
        public string DoCaptureCode(string authorization_id, string amount)
        {
            CallerServices caller = new CallerServices();
    
            IAPIProfile profile = ProfileFactory.createSSLAPIProfile();
    
            profile.APIUsername = "JMK";
            profile.APIPassword = "FooBar";
            profile.CertificateFile = @"~\MyTestCertificate.txt";
            profile.Environment = "sandbox";
            caller.APIProfile = profile;
    
            DoCaptureRequestType pp_request = new DoCaptureRequestType();
            pp_request.Version = "51.0";
    
            pp_request.AuthorizationID = authorization_id;
            pp_request.Amount = new BasicAmountType();
            pp_request.Amount.Value = amount;
            pp_request.Amount.currencyID = CurrencyCodeType.GBP;
            pp_request.CompleteType = CompleteCodeType.Complete;
    
            DoCaptureResponseType pp_response = new DoCaptureResponseType();
            pp_response = (DoCaptureResponseType)caller.Call("DoCapture", pp_request);
            return pp_response.Ack.ToString();
        }
    }
