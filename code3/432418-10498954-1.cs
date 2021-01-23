    public class MyService : IClientMessageInspector
    {
        public void DoWork()
        {
             // Do some stuff
        }
     
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            string message = reply.ToString();
            // Load the reply message in DOM for easier modification
            XmlDocument doc = new XmlDocument();
            doc.Load(reply.GetReaderAtBodyContents());
            // Perform the modification
            MessageHelper.FixArrays(doc);
            // Create New Message
            XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
            Message newMsg = Message.CreateMessage(reply.Version, reply.Headers.Action, reader);
            // Preserve the headers of the original message
            if (reply.Headers.Any())
                newMsg.Headers.CopyHeaderFrom(reply, 0);
            foreach (string propertyKey in reply.Properties.Keys)
            {
                newMsg.Properties.Add(propertyKey, reply.Properties[propertyKey]);
            }
            // Close the original message and return new message
            reply.Close();
            reply = newMsg;
        }
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            return null;
        }
    }
    public static class MessageHelper
    {
        public static void FixArrays(XmlDocument doc)
        {
            // Arrearage
            WrapElement(doc, "foo", "arrayItem", "http://url.com/namespace/foo");
        }
        private static void WrapElement(XmlDocument doc, string elementName, string wrapperName, string nameSpace)
        {
            var names = new XmlNamespaceManager(doc.NameTable);
            names.AddNamespace("a", nameSpace);
            var Nodes = doc.SelectNodes("//a:" + elementName, names);
            if (Nodes.Count > 0)
            {
                var newBorrower = doc.CreateElement(Nodes.Item(0).Prefix, wrapperName, Nodes.Item(0).NamespaceURI);
                foreach (XmlElement node in Nodes)
                {
                    newBorrower.AppendChild(node.Clone());
                }
                Nodes.Item(0).ParentNode.ReplaceChild(newBorrower, Nodes.Item(0));
                for (int i = 1; i <= Nodes.Count - 1; i++)
                {
                    Nodes.Item(i).ParentNode.RemoveChild(Nodes.Item(i));
                }
            }
        }
        private static void WrapRenameElement(XmlDocument doc, string newName, string elementName, string wrapperName, string nameSpace, string newNamespace)
        {
            var names = new XmlNamespaceManager(doc.NameTable);
            names.AddNamespace("a", nameSpace);
            names.AddNamespace("b", newNamespace);
            var Nodes = doc.SelectNodes("//a:" + elementName + "/..", names);
            foreach (XmlElement parent in Nodes)
            {
                var newBorrower = doc.CreateElement(parent.Prefix, wrapperName, parent.NamespaceURI);
                foreach (XmlElement child in parent.ChildNodes)
                {
                    if (child.LocalName == elementName)
                    {
                        var newNode = RenameNode(child.Clone(), newNamespace, newName);
                        parent.RemoveChild(child);
                        newBorrower.AppendChild(newNode);
                    }
                }
                if (newBorrower.ChildNodes.Count > 0)
                    parent.AppendChild(newBorrower);
            }
        }
        private static void WrapRenameElement(XmlDocument doc, string newName, string elementName, string wrapperName, string nameSpace)
        {
            var names = new XmlNamespaceManager(doc.NameTable);
            names.AddNamespace("a", nameSpace);
            var Nodes = doc.SelectNodes("//a:" + elementName + "/..", names);
            foreach (XmlElement parent in Nodes)
            {
                var newBorrower = doc.CreateElement(parent.Prefix, wrapperName, parent.NamespaceURI);
                foreach (XmlElement child in parent.ChildNodes)
                {
                    if (child.LocalName == elementName)
                    {
                        var newNode = RenameNode(child.Clone(), nameSpace, newName);
                        parent.RemoveChild(child);
                        newBorrower.AppendChild(newNode);
                    }
                }
                if (newBorrower.ChildNodes.Count > 0)
                    parent.AppendChild(newBorrower);
            }
        }
        public static XmlNode RenameNode(XmlNode node, string namespaceURI, string qualifiedName)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                XmlElement oldElement = (XmlElement)node;
                XmlElement newElement =
                node.OwnerDocument.CreateElement(qualifiedName, namespaceURI);
                while (oldElement.HasAttributes)
                {
                    newElement.SetAttributeNode(oldElement.RemoveAttributeNode(oldElement.Attributes[0]));
                }
                while (oldElement.HasChildNodes)
                {
                    newElement.AppendChild(oldElement.FirstChild);
                }
                if (oldElement.ParentNode != null)
                {
                    oldElement.ParentNode.ReplaceChild(newElement, oldElement);
                }
                return newElement;
            }
            else
            {
                return null;
            }
        }
    }
