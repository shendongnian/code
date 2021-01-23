        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var properties = reply.Properties;
            var contextKey = GetContextKey(properties);
            bool statusCodeFound = false;
            var statusCode = HttpStatusCode.OK;
            if (properties.Keys.Contains("httpResponse"))
            {
                statusCode = ((System.ServiceModel.Channels.HttpResponseMessageProperty)properties["httpResponse"]).StatusCode;
                statusCodeFound = true;
            }
            var buffer = reply.CreateBufferedCopy(int.MaxValue);
            //Must use a buffer rather than the origonal message, because the Message's body can be processed only once.
            Message msg = buffer.CreateMessage();
            //Setup StringWriter to use as input for our StreamWriter
            //This is needed in order to capture the body of the message, because the body is streamed.
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            msg.WriteMessage(xmlTextWriter);
            xmlTextWriter.Flush();
            xmlTextWriter.Close();
            var returnValue = stringWriter.ToString();
            // I do my logging of the "returnValue" variable here. You can do whatever you want.
            //Return copy of origonal message with unaltered State
            reply = buffer.CreateMessage();
        }
