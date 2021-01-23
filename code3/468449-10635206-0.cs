    protected void grdRetailStore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          if (e.Row.RowState == DataControlRowState.Normal)
          {
              Label lblAccount = (Label)e.Row.FindControl("lblCategoryName");
              string s = lblAccount.Text;
          }
          if (e.Row.RowState == DataControlRowState.Edit)
          {
              DropDownList ddlBlogCategory = (DropDownList)e.Row.FindControl("ddlBlogCategoty");
              if (ddlBlogCategory != null)
              {
                  //  ddlBlogCategory.Items.Clear();
                  ddlBlogCategory.DataSource = dao_category.SelectCategory();
                  ddlBlogCategory.DataTextField = "CategoryName";
                  ddlBlogCategory.DataValueField = "BlogCategoryID";
                  ddlBlogCategory.DataBind();
              }
          }
          DAO.DAO dao_category = new DAO.DAO();
          DataTable dt_blog_cat = dao_category.SelectCategory();
      }
    }
