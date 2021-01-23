        protected void StartImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton StartImageButton = (ImageButton)sender;
            StartImageButton.Visible = false;
            GridViewRow gr = (GridViewRow)StartImageButton.Parent.Parent;
            ImageButton StopImageButton = (ImageButton)gr.FindControl("StopImageButton");
            StopImageButton.Visible = true;
        }
