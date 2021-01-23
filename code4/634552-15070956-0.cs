       private static Message Transform(Message oldMessage)
        {
            //load the old message into XML
            var msgbuf = oldMessage.CreateBufferedCopy(int.MaxValue);
            var tmpMessage = msgbuf.CreateMessage();
            var xdr = tmpMessage.GetReaderAtBodyContents();
            var xdoc = new XmlDocument();
            xdoc.Load(xdr);
            xdr.Close();
            // We are making an assumption that the Operation element is the
            // first child element of the Body element
            var targetNodes = xdoc.SelectNodes("./*");
            // There should be only one Operation element
            var node = (null != targetNodes) ? targetNodes[0] : null;
            if (null != node)
            {
                if(null != node.Attributes) node.Attributes.RemoveNamedItem("xmlns");
                node.Prefix = "bb";
            }
            var ms = new MemoryStream();
            var xw = XmlWriter.Create(ms);
            xdoc.Save(xw);
            xw.Flush();
            xw.Close();
            ms.Position = 0;
            var xr = XmlReader.Create(ms);
            //create new message from modified XML document
            var newMessage = Message.CreateMessage(oldMessage.Version, null, xr);
            newMessage.Headers.CopyHeadersFrom(oldMessage);
            newMessage.Properties.CopyProperties(oldMessage.Properties);
            return newMessage;
        }
    }
