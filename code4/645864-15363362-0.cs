        DataTable dt = sqlselect(sqlQuery, parameter);
        var doc = new XmlDocument();
        doc.LoadXml(dt.Rows[0]["ua_post"].ToString());
        XmlNodeList nl = doc.SelectNodes("NewDataSet");
        XmlNode root = nl[0];
        foreach (XmlNode xnode in root.ChildNodes[0])
        {
            string name = xnode.Name;
            string value = xnode.InnerText;
            string nv = "<b>" + name + ":</b> " + value;
            Label1.Text += nv + " <br />" + Environment.NewLine;
        }
