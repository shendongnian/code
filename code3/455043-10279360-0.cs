    HtmlTableRow trContent = new HtmlTableRow(); 
    HtmlTableCell cell1 = new HtmlTableCell(); 
    HyperLink hl = new HyperLink() 
    { 
        Text = "?", 
        NavigateUrl = "#TB_inline?height=200&width=300&inlineId=myOnPageContent",
        CssClass="thickbox", 
        ToolTip = "add a caption to title attribute" 
    };
    cell1.Controls.Add(hl); 
    trContent.Cells.Add(cell1)
