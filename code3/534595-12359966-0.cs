    private BusinessServiceClient _client;
    void Page_Init()
    {
        if (Session["client"] == null) 
        {
            _client = InstantiateWCFService();
            Session["client"] = _client;
        }
        else
        {
            _client = (BusinessServiceClient) Session["client"];
        }
    }
