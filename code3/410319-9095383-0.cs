     protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            string closeImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "CustomExtenders.ListComplete.close.gif");
            //LiteralControl include = new LiteralControl(closeImageUrl);
            Label lblCloseImageUrl = new Label();
            lblCloseImageUrl.ID = "lblCloseImageUrlListCompleteExtender";
            lblCloseImageUrl.ViewStateMode = ViewStateMode.Disabled;
            lblCloseImageUrl.EnableViewState = false;
            lblCloseImageUrl.Text = closeImageUrl;
            lblCloseImageUrl.Attributes["style"] = "display: none;";
            this.Page.Header.Controls.Add(lblCloseImageUrl);
        }
