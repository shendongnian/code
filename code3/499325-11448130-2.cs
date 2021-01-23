    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, 
        ResponseFormat = WebMessageFormat.Json, 
        RequestFormat = WebMessageFormat.Json)]
        public int GetOne(string param1, string param2)
        {
            return 1;
        }
