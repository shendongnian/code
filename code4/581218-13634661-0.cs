    public void GetWebsitesWithListFeed(string sheetName)
        {
            //List<string> websites = new List<string>();
            WorksheetEntry entry = //get your spreadsheet (expmples for this can be found
                                  //in google docs api (link in the end of the answer)
            // Define the URL to request the list feed of the worksheet.
            AtomLink listFeedLink = entry.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
            
            // Fetch the list feed of the worksheet.
            ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
            ListFeed listFeed = service.Query(listQuery);
            // Iterate through each row, printing its cell values.
            foreach (ListEntry row in listFeed.Entries)
            {
                //go over each CELL in the row
                foreach (ListEntry.Custom element in row.Elements)
                {   
                    //print only the CELLS that there father (xmlName) is "WebsiteList2"
                    if (element.XmlName == "WebsiteList2")
                        Console.WriteLine(element.Value);
                }
            }
        }
