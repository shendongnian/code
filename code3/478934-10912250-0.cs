        void GetElements(XmlNode inXmlNode)
        {
            if(inXmlNode.HasChildNodes)
            {
                foreach (XmlNode childNode in inXmlNode.ChildNodes)
                {
                    GetElements(childNode);
                }
            }
            else
            {
                listBox1.Items.Add(inXmlNode.Name);
            }
        }
