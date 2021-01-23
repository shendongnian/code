        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var test = OperationContext.Current.Extensions.Find<ContextSessionExtension>().SomeData;
            object httpRequestMessageObject;
            HttpRequestMessageProperty httpRequestMessage;
            if (reply.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                if (string.IsNullOrEmpty(httpRequestMessage.Headers["MYTEST"]))
                {
                    httpRequestMessage.Headers["MYTEST"] = test;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add("MYTEST", test);
                reply.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
        }
