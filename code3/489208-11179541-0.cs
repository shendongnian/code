       protected void Page_Load(object sender, System.EventArgs  e){
        System.Web.UI.HtmlControls.HtmlTableRow tr = new HtmlTableRow();
        //setting the style of a table row using the Attributes property
        tr.Attributes.Add("style", "width:500px; background-color:red");
        HtmlTableCell tc = new HtmlTableCell();
        tc.InnerHtml = "this is a test";
        tr.Controls.Add(tc);
        this.table1.Controls.Add(tr);
