        private void OnMessage(IMessage msg)
        {
            IBytesMessage bytesMessage = (IBytesMessage)msg;
            var buffer = new byte[bytesMessage.BodyLength];
            bytesMessage.ReadBytes(buffer, (int)bytesMessage.BodyLength);
            var messageAsText = Encoding.Unicode.GetString(buffer);
            Console.Write("Got a message: ");
            Console.WriteLine(messageAsText);
        }
