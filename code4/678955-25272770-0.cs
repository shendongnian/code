             XmlDocument doc = new XmlDocument();
            doc.Load(path);// write xml path
            XmlNodeList elemList = doc.GetElementsByTagName("ID");
            for (int i = 0; i < elemList.Count; i++)
            {
                string ID = elemList[i].Attributes["ID"].Value;
               listBox1.Items.Add(ID);
              
            }
