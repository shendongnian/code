    public XElement callRequestFunc(XElement request)
        {
            ServiceProviderTic requestSer = Utility.DeserializeData(request);
            if (requestSer.Item.GetType() == typeof(RequestType))
            {
                RequestType reqObj = (RequestType)requestSer.Item;
                string datapiece = reqObj.MsgType.ToString();
            }
            XElement responseSer = Utility.SerializeData(requestSer);
            return responseSer;
        }
    }
