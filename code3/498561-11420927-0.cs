    private GridView1_RowDatabound(object sender,EventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
         // You have to put your logic here. 
           if( e.Row.Cells[1].Text = "closed" ) 
           {
                // to get a reference to label control
               Label lb = e.Row.FindControl("LabelCOntrolID");
                     
           }
 
       }               
    }
 
