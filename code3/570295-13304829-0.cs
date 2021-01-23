    GridViewRow gvr = e.Row;
    selectedID = (GridView1.DataKeys[e.Row.RowIndex].Value.ToString());
                gvr.Attributes.Add("OnClick","javascript:location.href='Views/EditMenus/EditCompany.aspx?id=" + selectedID + "'");
    
    gvr.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFE6E6'");
    gvr.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
    gvr.Attributes.Add("style", "cursor:pointer;");
    
    Session["IDs"] = selectedID;
