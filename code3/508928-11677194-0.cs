            var xmlPath = @"C:\Projects\Research\StackOverflow\StackOverflow\test.xml";
            // Loading the xml file
            var xmlDoc=XDocument.Load(xmlPath);
            // Querying the names of the parents from the above xml file.
            var parentList = from p in xmlDoc.Descendants("Parent") select new { Name = p.Attribute("Name").Value };
            var PList=parentList.ToList();
            //passing to list to the gridview in asp.net web page:
             gvParentsList.DataSource = PList;
             gvParentsList.DataBind();
