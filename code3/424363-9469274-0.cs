    protected void grvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    //...
                    break;
                case DataControlRowType.DataRow:
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
                    if (e.Row.RowState == DataControlRowState.Alternate)
                    {
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", grvSearch.AlternatingRowStyle.BackColor.ToKnownColor()));
                    }
                    else
                    {
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", grvSearch.RowStyle.BackColor.ToKnownColor()));
                    }
                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grvSearch, "Select$" + e.Row.RowIndex.ToString()));
                    break;
            }
        }
        catch 
        {
            //...throw
        }
    }
