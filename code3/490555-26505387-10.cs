    public class ToStringInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name != "ToString")
            {
                invocation.Proceed();
            }
            else
            {
                var result = string.Empty;
                var msg = invocation.InvocationTarget as Message;
                StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
                XmlDictionaryWriter xmlDictionaryWriter =
                    XmlDictionaryWriter.CreateDictionaryWriter(new XmlTextWriter(stringWriter));
                try
                {
                    ProcessMessage(msg, xmlDictionaryWriter);
                    xmlDictionaryWriter.Flush();
                    result = stringWriter.ToString();
                }
                catch (XmlException ex)
                {
                    result = "ErrorMessage";
                }
                invocation.ReturnValue = result;
            }
        }
        private void ProcessMessage(Message msg, XmlDictionaryWriter writer)
        {
            // same method as above
        }
    }
