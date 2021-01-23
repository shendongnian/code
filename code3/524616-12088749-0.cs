    public void GridView1_Delete_Record (Object sender, GridViewDeleteEventArgs e)
    {
        string id = gridView1.Rows[e.RowIndex].Cells[2].Text;
        ASB_DataDataContext db = new ASB_DataDataContext();
        var delCase = from dc in db.Inputts
                  where dc.counter == Convert.ToInt32(id)
                  select dc;
    
        foreach (var nCase in delCase)
        {
           db.Inputts.DeleteOnSubmit(nCase);
           db.SubmitChanges();
        }  Message.Text = "";
    }  
