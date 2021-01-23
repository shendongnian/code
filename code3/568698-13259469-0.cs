    foreach (GridViewRow gr in GridView1.Rows)
    {
       var cells = gr.Cells;
       CheckBox cb = (CheckBox)gr.FindControl("chkItem");
       if (cb.Checked)
       {
          string strTargetDate = cells[0].Text;
       }
    }
