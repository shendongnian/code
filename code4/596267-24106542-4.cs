    public static CustomBinding ServiceBinding
    {
        get
        {
            if (binding != null)
            {
                return binding;
            }
            binding = new CustomBinding
            {
                CloseTimeout = new TimeSpan(0, 2, 0),
                ReceiveTimeout = new TimeSpan(0, 3, 0),
                SendTimeout = new TimeSpan(0, 5, 0)
            };
            var ssbe = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            binding.Elements.Add(ssbe);
            binding.Elements.Add(new BinaryMessageEncodingBindingElement());
            binding.Elements.Add(
                new HttpsTransportBindingElement { MaxReceivedMessageSize = 2147483647, MaxBufferSize = 2147483647 });
            return binding;
        }
    }
