       //using System.Data;
       public DataTable getNodesData(XmlNodeList nodes)
        {
            DataTable dt = new DataTable();
            if (nodes.Count <= 0)
                return dt;
            foreach (XmlNode childnode in nodes[0].ChildNodes)
                dt.Columns.Add(childnode.Name);
            foreach (XmlNode node in nodes)
            {
                DataRow dr = dt.NewRow();
                foreach (XmlNode childnode in node.ChildNodes)
                    dr[childnode.Name] = childnode.InnerText;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        XmlNodeList nodes = DOC.GetElementsByTagName("CheckMarkObject");
        DataTable dt = getNodesData(nodes); 
        //Bind your dt to GridView, DataList, Repeater etc
