        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                //render control for designer...
                writer.Write(string.Format("<div>{0}</div>", this.ID));
            }
            else
            {
                //render actual control in runtime...
                base.Render(writer);
            }
        } 
