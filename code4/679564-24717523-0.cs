          protected void Page_Load(object sender, EventArgs e)
        {
            HtmlHead header1 = (HtmlHead)Master.FindControl("head1");
            header1.Controls.Remove(header1.FindControl("desc1"));
            HtmlMeta description = new HtmlMeta();
            //System.Web.UI.HtmlControls.HtmlMeta description = new System.Web.UI.HtmlControls.HtmlMeta();
            
            description.Name = "description";
            description.Content = "We are a family owned and operated painting company. We serve homeowners in Northern Virginia and Washington DC";
            this.Header.Controls.Add(description);
        }
