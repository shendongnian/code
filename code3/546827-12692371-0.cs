        //untested
        foreach (DataRow categoryRow in reader.GetChildRows("Category"))
        {
          //myNode.LastChild.InnerText = categoryRow["CATEGORY_NAME"].ToString();
            var newNode = myNode.Document.CreateElement("Value");
            newNode.InnerText = categoryRow["CATEGORY_NAME"].ToString();
            myNode.AppendChild(newNode);
        }
 
