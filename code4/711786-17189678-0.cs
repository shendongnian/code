        ImageButton ibtn1 = sender as ImageButton;
        
        GridView grd = sender as GridView;
        
        string gridName = grd.ClientID;
        string buttonId = e.CommandName;
        
        using (GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer)
        {
            txtMessageID.ReadOnly = true;
            txtMessageID.Text = row.Cells[2].Text;
            if (gridName == "grdMessageDups")
            {
                txtReference.Text = row.Cells[6].Text;
            }
            buttonClicked.Text = ibtn1.ID.ToString();
            popup.Show();
        }
    }
