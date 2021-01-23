        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var httpResponse =
                reply.Properties[HttpResponseMessageProperty.Name] 
                       as HttpResponseMessageProperty;
            if (httpResponse != null)
            {
                string cookie = httpResponse.Headers[HttpResponseHeader.SetCookie];
                if (!string.IsNullOrEmpty(cookie))
                {
                    System.Web.HttpContext.Current.Items.Add("MyCookies", cookie);
                }
            }
        }
