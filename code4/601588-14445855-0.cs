    <asp:ImageButton ID="Img_Update" runat="server" CommandName="Change" CommandArgument='<%# Eval("emailNewsletter") %>' ImageUrl="~/images/GridIcon/update.png" ToolTip="Update" />
--------------------------------
    protected void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Change":
                ImageButton btnNew = e.CommandSource as ImageButton;
                GridViewRow row = btnNew.NamingContainer as GridViewRow;
                TextBox txt_emailNewsletter = row.FindControl("txt_emailNewsletter") as TextBox;
                if ( !CheckEmail(e.CommandArgument.ToString()) || !CheckEmail(txt_emailNewsletter.Text) )
                    lbl_result.Text = "ERROR : Email not Valid";
                else {
                    if (txt_emailNewsletter.Text.Trim().ToLower() == e.CommandArgument.ToString())
                        lbl_result.Text = "Email values are indentical";
                    else
                    {
                        //Business Layer Call
                        NewsLetterBL newsBl2 = new NewsLetterBL();
                        if (newsBl2.ModifyWrongEmail(e.CommandArgument.ToString(), txt_emailNewsletter.Text.Trim().ToLower()))
                            lbl_result.Text = "Email Changed";
                        else
                            lbl_result.Text = "ERROR : " + newsBl2.LastMessage;
                    }
                }
            
                LoadDataForGridView(((GridView)sender));
                BindGridView(((GridView)sender), -1, ((GridView)sender).PageIndex);
                break;
        }
    }
