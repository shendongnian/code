    protected void grdKeywords_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkDeleteButton = e.Row.FindControl("lnkdel") as LinkButton;
                Label lblGridKeyword = e.Row.FindControl("lblGridKeyword") as Label;
                TextBox txtGridBox = e.Row.FindControl("txtGridKeyword") as TextBox;
                if (lblGridKeyword != null)
                {
                    if (lblGridKeyword.Text.Contains("'"))
                    {
                        lblGridKeyword.Text = lblGridKeyword.Text.Replace("'", "&#39;");
                    }
                }
                if (txtGridBox != null)
                {
                    if (txtGridBox.Text.Contains("'"))
                    {
                        txtGridBox.Text = txtGridBox.Text.Replace("'", "`");
                    }
                }
                if (txtGridBox == null)
                    linkDeleteButton.Attributes.Add("onclick", "javascript:return confirm('Are you sure about deleting keyword: " + lblGridKeyword.Text + " ?')");
                else if (lblGridKeyword == null)
                    linkDeleteButton.Attributes.Add("onclick", "javascript:return confirm('Are you sure about deleting keyword: " + txtGridBox.Text + " ?')");
            }
        }
