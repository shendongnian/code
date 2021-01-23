		public void validateIputXML(string inputXmlPath)
		{
			
			XmlDocument document = new XmlDocument();
			document.Load(inputXmlPath);
			XmlNodeList recipientItem = document.GetElementsByTagName("RECIPIENT");
			foreach (XmlNode childList in recipientItem)
			{
				string attibuteValue_TemplateID = getValue(childList,".//LETTER_HEADER/TEMPLATE_ID");
				string attibuteValue_ProviderName = getValue(childList,".//LETTER_BODY/PROVIDER_INFO/PROVIDER_NAME");
				string attibuteValue_ProviderAddress = getValue(childList,".//LETTER_BODY/PROVIDER_INFO/PROVIDER_ADDRESS1");
				string attibuteValue_ProviderNumber = getValue(childList,".//LETTER_BODY/PROVIDER_INFO/PROVIDERNPI");
				
				Report.Info(attibuteValue_TemplateID+"-->"+attibuteValue_ProviderName+"-->"+attibuteValue_ProviderAddress+"-->"+attibuteValue_ProviderNumber);
			}
		}
        public string getValue(XmlNode Xnode, string attributeName)
		{
			XmlNode innerNode = Xnode.SelectSingleNode(attributeName);
			string attributeValue = innerNode.InnerText;
			return attributeValue;
		}
