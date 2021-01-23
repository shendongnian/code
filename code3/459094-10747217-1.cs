        public static bool verifyDigitalSignatureForString(string msgAsString)
        {
            XmlDocument verifyDoc = new XmlDocument();
            verifyDoc.PreserveWhitespace = true;
            verifyDoc.LoadXml(msgAsString);
            SignedXmlWithId verifyXml = new SignedXmlWithId(verifyDoc);
            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = verifyDoc.GetElementsByTagName("Signature");
            // Load the signature node.
            verifyXml.LoadXml((XmlElement)nodeList[0]);
            if (verifyXml.CheckSignature())
            {
                Console.WriteLine("Digital signature is valid");
                return true;
            }
            else
            {
                Console.WriteLine("Digital signature is not valid");
                return false;
            }
        }
