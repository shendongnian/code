    //getting the awards list and extracting correct values from the necesary fields
    //asp running with elevated privilegs
    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
    using (SPSite site = new SPSite(webUrl))
    {
    using (SPWeb web = site.OpenWeb())
    {
                       
    try
    {
    SPList awardsList = web.Lists["Awards"];
    SPListItemCollection listItemCollection = awardsList.Items;
                                                                         
    //getting all list items and displaying them next to each other row by row
                            
    //int modCounter = 0;
    //Creating the table
    Table tbl = new Table();
    //foreach (SPListItem oListItem in listItemCollection)
    int x = listItemCollectionI.Count;
    for(int i = 0; (i * 2) < x; i++) // divide total item collection by two, each loop 
    iteration, add two awards to a row (left cell, right cell)
    {
    // get listItemCollection[i];
    //Create table rows, table cells
    int leftIndexer = i * 2;
    int rightIndexer = (i * 2) + 1;
    if (leftIndexer == x)
    {
    break;
    }                                
    TableRow tblRow = new TableRow();
    TableCell tblCellLeft = new TableCell(); //for the awards in the first column
    TableCell tblCellRight = new TableCell(); //for the awards in the second column
    tblCellLeft.VerticalAlign = VerticalAlign.Top;
    tblCellLeft.HorizontalAlign = HorizontalAlign.Center;
    tblCellLeft.CssClass = ("style5");
    tblCellRight.VerticalAlign = VerticalAlign.Top;
    tblCellRight.HorizontalAlign = HorizontalAlign.Center;
    // get the values
    awardYear = listItemCollection[leftIndexer]["Title"].ToString();
    awardCategory = listItemCollection[leftIndexer]["Category"].ToString();
    awardNomWon = listItemCollection[leftIndexer]["NominatedWon"].ToString();
    if(listItemCollection[leftIndexer]["Logo"] != null)
    awardLogo = (string)listItemCollection[leftIndexer]["Logo"];
                            
    // add to left cell
    //values for the left column
    tblCellLeft.Controls.Add(new LiteralControl("<div class=\"style1\">" + awardYear + 
    "</div>"));
    tblCellLeft.Controls.Add(new LiteralControl("<div class=\"style2\">" + awardCategory + 
    "</div>"));
    tblCellLeft.Controls.Add(new LiteralControl("<div class=\"style3\">" + awardNomWon + 
    "</div>"));
    tblCellLeft.Controls.Add(new LiteralControl("<div class=\"style4\">" + "<img src=" + 
    awardLogo.Replace(",", "") + "</div>"));
                                
    // add left cell to row
    tblRow.Cells.Add(tblCellLeft);
    if (rightIndexer < x) // if this item exists in the collection (prevent bug with odd 
    number of awards)
    {
                                    
    // get the values
    awardYear = listItemCollection[rightIndexer]["Title"].ToString();
    awardCategory = listItemCollection[rightIndexer]["Category"].ToString();
    awardNomWon = listItemCollection[rightIndexer]["NominatedWon"].ToString();
                                    
    if (listItemCollection[rightIndexer]["Logo"] != null)
        awardLogo = (string)listItemCollection[rightIndexer]["Logo"];
                                    
    // add to right cell
    //Values for the right column
    tblCellRight.Controls.Add(new LiteralControl("<div class=\"style1\">" + awardYear + 
    "</div>"));
    tblCellRight.Controls.Add(new LiteralControl("<div class=\"style2\">" + awardCategory 
    + "</div>"));
    tblCellRight.Controls.Add(new LiteralControl("<div class=\"style3\">" + awardNomWon + 
    "</div>"));
    tblCellRight.Controls.Add(new LiteralControl("<div class=\"style4\">" + "<img src=" + 
    awardLogo.Replace(",", "") + "</div>"));
    //add right cell to row
    tblRow.Cells.Add(tblCellRight);
   
    }
    // add row to table
    tbl.Rows.Add(tblRow);
                         
    }
    PlaceHolder6.Controls.Add(tbl); // add table outside of loop 
    }
    catch (Exception err)
    {
    PlaceHolder3.Controls.Add(new LiteralControl(err.ToString()));
    }
                   
    }
    }
        
    });
