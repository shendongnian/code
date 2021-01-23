        public GetItemCall getItemDataFromEbay(String itemId)
        {
            ApiContext oContext = new ApiContext();
            oContext.ApiCredential.ApiAccount.Developer = ""; // use your dev ID
            oContext.ApiCredential.ApiAccount.Application = ""; // use your app ID
            oContext.ApiCredential.ApiAccount.Certificate = ""; // use your cert ID
            oContext.ApiCredential.eBayToken = "";            //set the AuthToken
            //set the endpoint (sandbox) use https://api.ebay.com/wsapi for production
            oContext.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            //set the Site of the Context
            oContext.Site = eBay.Service.Core.Soap.SiteCodeType.US;
            //the WSDL Version used for this SDK build
            oContext.Version = "735";
            //very important, let's setup the logging
            ApiLogManager oLogManager = new ApiLogManager();
            oLogManager.ApiLoggerList.Add(new eBay.Service.Util.FileLogger("GetItem.log", true, true, true));
            oLogManager.EnableLogging = true;
            oContext.ApiLogManager = oLogManager;
            GetItemCall oGetItemCall = new GetItemCall(oContext);
            //' set the Version used in the call
            oGetItemCall.Version = oContext.Version;
            //' set the Site of the call
            oGetItemCall.Site = oContext.Site;
            //' enable the compression feature
            oGetItemCall.EnableCompression = true;
            oGetItemCall.DetailLevelList.Add(eBay.Service.Core.Soap.DetailLevelCodeType.ReturnAll);
            oGetItemCall.ItemID = itemId;
            try
            {
                oGetItemCall.GetItem(oGetItemCall.ItemID);
            }
            catch (Exception E)
            {
                Console.Write(E.ToString());
                oGetItemCall.GetItem(itemId);
            }
            GC.Collect();
            return oGetItemCall;
        }
