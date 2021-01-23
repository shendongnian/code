    namespace API
    {
    public class APIKeyAuthorization : ServiceAuthorizationManager
    {
        public const string APIKEY = "APIKey";
        public const string APIKEYLIST = "APIKeyList";
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            return IsValidAPIKey(operationContext);
        }
        public bool IsValidAPIKey(OperationContext operationContext)
        {
            // if verification is disabled, return true
            if (Global.APIKeyVerification == false)
                return true;
            string key = GetAPIKey(operationContext);
            // Convert the string into a Guid and validate it
            if (BusinessLogic.User.ApiKey.Exists(key))
            {
                return true;
            }
            else
            {
                // Send back an HTML reply
                CreateErrorReply(operationContext, key);
                return false;
            }
        }
        public string GetAPIKey(OperationContext operationContext)
        {
            // Get the request message
            var request = operationContext.RequestContext.RequestMessage;
            // Get the HTTP Request
            var requestProp = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            // Get the query string
            NameValueCollection queryParams = HttpUtility.ParseQueryString(requestProp.QueryString);
            // Return the API key (if present, null if not)
            return queryParams[APIKEY];
        }
        private static void CreateErrorReply(OperationContext operationContext, string key)
        {
            // The error message is padded so that IE shows the response by default
            using (var sr = new StringReader("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + APIErrorHTML))
            {
                XElement response = XElement.Load(sr);
                using (Message reply = Message.CreateMessage(MessageVersion.None, null, response))
                {
                    HttpResponseMessageProperty responseProp = new HttpResponseMessageProperty() { StatusCode = HttpStatusCode.Unauthorized, StatusDescription = String.Format("'{0}' is an invalid API key", key) };
                    responseProp.Headers[HttpResponseHeader.ContentType] = "text/html";
                    reply.Properties[HttpResponseMessageProperty.Name] = responseProp;
                    operationContext.RequestContext.Reply(reply);
                    // set the request context to null to terminate processing of this request
                    operationContext.RequestContext = null;
                }
            }
        }
        public const string APIErrorHTML = @"
    <html>
    <head>
        <title>Request Error - No API Key</title>
        <style type=""text/css"">
            body
            {
                font-family: Verdana;
                font-size: x-large;
            }
        </style>
    </head>
    <body>
        <h1>
            Request Error
        </h1>
        <p>
            A valid API key needs to be included using the apikey query string parameter
        </p>
    </body>
    </html>
    ";
        }
    }
