            XmlNode node = nl[0]; 
            String sPath = node.Name;
            System.Xml.XmlNode np = node.ParentNode;
            while (np != null && np.NodeType != XmlNodeType.Document)
            {
                sPath = String.Format("{0}/{1}", np.Name, sPath);
                np = np.ParentNode;
            }
            sPath = "/" + sPath;
            Debug.WriteLine(sPath);
