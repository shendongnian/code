    public interface IOmniData
        {
            [OperationContract]
            [WebGet(UriTemplate = "OmniData/GetAllCountries", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            Country[] GetAllCountries();
        }
