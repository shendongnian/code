    if (ControllerContext.HttpContext.Request.Form["wresult"] != null)
                {
                    // This is a response from the ACS - you can further inspect the message if you will
                    SignInResponseMessage message =
                        WSFederationMessage.CreateFromNameValueCollection(
                        WSFederationMessage.GetBaseUrl(ControllerContext.HttpContext.Request.Url),
                        ControllerContext.HttpContext.Request.Form)
                        as SignInResponseMessage;
    
                    if (!string.IsNullOrWhiteSpace(message.Context))
                    {
                        // do whatever you want with the context value
                    }
                }
