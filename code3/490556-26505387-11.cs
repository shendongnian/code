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
            msg.WriteStartEnvelope(writer);
            msg.WriteStartBody(writer);
            var bodyToStringMethod = msg.GetType()
                .GetMethod("BodyToString", BindingFlags.Instance | BindingFlags.NonPublic);
            bodyToStringMethod.Invoke(msg, new object[] { writer });
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var msg = Message.CreateMessage(MessageVersion.Soap11, "*");
            msg.Headers.Clear();
            var proxyGenerator = new Castle.DynamicProxy.ProxyGenerator();
            var proxiedMessage = proxyGenerator.CreateClassProxyWithTarget(msg, new ProxyGenerationOptions(),
                new ToStringInterceptor());
            var initialResult = msg.ToString();
            var proxiedResult = proxiedMessage.ToString();
            Console.WriteLine("Initial result");
            Console.WriteLine(initialResult);
            Console.WriteLine();
            Console.WriteLine("Proxied result");
            Console.WriteLine(proxiedResult);
            Console.ReadLine();
        }
    }
