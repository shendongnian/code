        public static string GetSmtpPickupFolder()
        {
            var doc = new XmlDocument();
            var fileName = Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.Windows), @"System32\inetsrv\MetaBase.xml");
            if (!File.Exists(fileName))
            {
                return null;
            }
            doc.Load(fileName);
            var nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("c", doc.DocumentElement.NamespaceURI);
            var node = doc.SelectSingleNode(
                "/c:configuration/c:MBProperty/c:IIsSmtpServer", nsMgr);
            if (node == null)
            {
                return null;
            }
            var attr = node.Attributes["PickupDirectory"];
            if (attr == null)
            {
                return null;
            }
            return attr.Value;
        }
