    using Intuit.Ipp.Core;
    using Intuit.Ipp.Security;
    using Intuit.Ipp.Services;
    using Intuit.Ipp.Data;
    using Intuit.Ipp.AsyncServices;
    using Intuit.Ipp.Data.Qbo; 
    
    OAuthRequestValidator oauthValidator = new OAuthRequestValidator(
    "a",
    "b",
    "c",
    "d"
    );
    ServiceContext context = new ServiceContext (oauthValidator, companyID, IntuitServicesType.QBO);
    DataServices objDataService = new DataServices(context);
