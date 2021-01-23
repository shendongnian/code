      decimal sumFooterValue = 0;
      protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
             string sponsorBonus = ((Label)e.Row.FindControl("Label2")).Text;
             string pairingBonus = ((Label)e.Row.FindControl("Label3")).Text;
             string staticBonus = ((Label)e.Row.FindControl("Label4")).Text;
             string leftBonus = ((Label)e.Row.FindControl("Label5")).Text;
             string rightBonus = ((Label)e.Row.FindControl("Label6")).Text;
             decimal totalvalue = Convert.ToDecimal(sponsorBonus) + Convert.ToDecimal(pairingBonus) + Convert.ToDecimal(staticBonus) + Convert.ToDecimal(leftBonus) + Convert.ToDecimal(rightBonus);
             e.Row.Cells[6].Text = totalvalue.ToString();
     	     sumFooterValue += totalvalue; 
            }
     	
    	if (e.Row.RowType == DataControlRowType.Footer)
            {
               Label lbl = (Label)e.Row.FindControl("lblTotal");
               lbl.Text = sumFooterValue.ToString();
            }
    
       }
