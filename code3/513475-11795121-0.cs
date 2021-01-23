    protected void gvMyGrid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
     {
     if (e.Row.RowType == DataControlRowType.DataRow) {
     LinkButton lnkSil = (LinkButton)e.Row.FindControl("lnkSil");
     lnkSil.Attributes.Add("onclick", "javascript:return confirm('Bu kaydi silmek istediginizden emin misiniz?');");
         }
     }
