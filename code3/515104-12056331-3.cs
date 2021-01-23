     protected void lnk_Sort(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string arg = lnk.CommandArgument.ToString();
        ViewState["sortCol"] = arg;
        GetSortDirection();
        BindData(ViewState["sortCol"].ToString(), ViewState["sortDir"].ToString(), Convert.ToInt32(ViewState["nmbr"]), Pager.PageSize);
        string name = lnk.ID;
        Image img = (Image)(lst_Area.FindControl("img_" + name));
        if (img != null)
        {
            SetSortOrderImage(img, ViewState["sortDir"].ToString());
        }
    }
    private void SetSortOrderImage(Image image, String sortorder)
    {
        if (sortorder == "asc")
        {
            image.Visible = true;
            image.ImageUrl = "../App_Themes/ThemeNew2/images/up.png";
        }
        else if (sortorder == "Desc")
        {
            image.Visible = true;
            image.ImageUrl = "../App_Themes/ThemeNew2/images/down.png";
        }
    }
    /// <summary>
    /// this method get the sort direction
    /// </summary>
    private void GetSortDirection()
    {
        if (Convert.ToString(ViewState["sortDir"]) == "Desc")
        {
            ViewState["sortDir"] = "asc";
        }
        else
        {
            ViewState["sortDir"] = "Desc";
        }
    }
