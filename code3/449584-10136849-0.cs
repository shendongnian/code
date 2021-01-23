     protected void imgEdit_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton im1 = (ImageButton)sender;
            GridViewRow grv1 = (GridViewRow)im1.Parent.Parent;
            string id = grv1.Cells[0].Text.ToString();
            // pass this Id value into your query string for update operation. better way you follow three-tier architecture.
        }
