    protected void CashPayButton_Click(object sender, EventArgs e)
    {
    	
    
        foreach(Gridviewrow gvr in Cash_GridView.Rows)
        {
           if(((CheckBox)gvr.findcontrol("MemberCheck")).Checked == true)
           {
    
              int uPrimaryid= gvr.cells["uPrimaryID"];
           }
        }
    }
