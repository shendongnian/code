    HtmlTableRow gRow = Pages.PAPage.ApptsTableGrid.Rows[counter + i];
    foreach(HtmlTableCell gCell in gRow.Cells) 
    {    
        if(gCell.CssClass=="rgExpandCol")
        { 
            gCell.MouseClick();  
            ActiveBrowser.RefreshDomTree();
            System.Threading.Thread.Sleep(1000); 
           
        }  
    }
    counter++; 
} 
