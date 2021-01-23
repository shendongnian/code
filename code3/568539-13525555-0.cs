        /// <summary>
        /// Creates a custom SoapException to submit the client detailed information about the thrown errors
        /// </summary>
        /// <param name="uri">the name of the called method</param>
        /// <param name="webServiceNamespace">iShare_Services</param>
        /// <param name="errorMessage">the thrown error message</param>
        /// <param name="errorSource">the method which caused the error</param>
        /// <param name="code">Server or Client error?</param>
        /// throw RaiseException("MyMethod", "Service", ee.Message,
        /// ee.TargetSite.Name, FaultCode.Client);
        /// <returns></returns>
        public SoapException RaiseException(string uri, string webServiceNamespace,
            string errorMessage, string errorSource, FaultCode code)
        {
            XmlQualifiedName faultCodeLocation = null;
            //Identify the location of the FaultCode
            switch (code)
            {
                case FaultCode.Client:
                    faultCodeLocation = SoapException.ClientFaultCode;
                    break;
                case FaultCode.Server:
                    faultCodeLocation = SoapException.ServerFaultCode;
                    break;
            }
            XmlDocument xmlDoc = new XmlDocument();
            //Create the Detail node
            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //Build specific details for the SoapException
            //Add first child of detail XML element.
            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error", webServiceNamespace);
            //Create and set the value for the ErrorMessage node
            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", webServiceNamespace);
            errorMessageNode.InnerText = errorMessage;
            //Create and set the value for the ErrorSource node
            XmlNode errorSourceNode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource", webServiceNamespace);
            errorSourceNode.InnerText = errorSource;
            //Append the Error child element nodes to the root detail node.
            errorNode.AppendChild(errorMessageNode);
            errorNode.AppendChild(errorSourceNode);
            //Append the Detail node to the root node
            rootNode.AppendChild(errorNode);
            //Construct the exception
            SoapException soapEx = new SoapException(errorMessage, faultCodeLocation, uri, rootNode);
            //Raise the exception  back to the caller
            return soapEx;
        }
