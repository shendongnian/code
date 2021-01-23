     XDocument doc = XDocument.Load(CSDBpath + projectName + "\\Data.xml");
     var DMCs = from item in doc.Descendants("dataModule")
                select new {
                            dmc: item.Element("techName").Value, 
                            techName: item.Element("DMC").Value, 
                            infoName: item.Element("infoName").Value, 
                            status: item.Element("status").Value, 
                            notes: item.Element("notes").Value, 
                           };
     ListViewItem item = null;
     foreach (var dmc in DMCs)
     {
         item = new ListViewItem(dmc);
         listView1.Items.Add(item);
     }
