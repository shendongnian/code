    protected void ddlGift1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlGift1.SelectedValue == "41")
        {
           SetCOB(41, ddlFName1);
        }
        .....
    }
    private void SetCOB(int id, DropDownList name)
    {
        var _db = (from a in _foundation.COB
           where a.id == id 
          orderby a.id
          select new { a.id, a.name });
        .....
    }
