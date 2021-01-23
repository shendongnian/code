        //untested
        foreach (DataRow categoryRow in reader.GetChildRows("Category"))
        {
          //myNode.LastChild.InnerText = categoryRow["CATEGORY_NAME"].ToString();
            var newNode = myNode.OwnerDocument.CreateElement("value");
            newNode.InnerText = categoryRow["CATEGORY_NAME"].ToString();
            myNode.AppendChild(newNode);
        }
 
