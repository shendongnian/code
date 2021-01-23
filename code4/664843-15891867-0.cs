                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(@"..\..\XMLFile1.xml");
                XmlNode root = myXmlDocument.DocumentElement;
                //We only want to change one connection. 
                //This could be removed if you just want the first connection, regardless of name.
                var targetKey = "sqlConnection1";
                
                //get the add element we want
                XmlNode myNode = root.SelectSingleNode(string.Format("add[@Name = '{0}']", targetKey));
                var sql_Connection = "some sql connection";
                //set the value of the connectionString attribute to the value we want
                myNode.Attributes["connectionString"].Value = sql_Connection;
                myXmlDocument.Save(@"..\..\XMLFile2.xml");
