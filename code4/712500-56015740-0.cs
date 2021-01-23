        --------aspx page code---------
        
         <asp:GridView ID="gvLibrary" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="LibMstRefNo"
                            EmptyDataText="No Client Found" CssClass="table table-striped table-bordered" OnRowDataBound="gvLibrary_RowDataBound">
                            <Columns>
         <asp:TemplateField HeaderText="Issue">
                                <ItemTemplate>
                                   <asp:LinkButton ID="lnkIssue" runat="server" Text="Issue" OnClick="lnkIssue_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receive">
                                <ItemTemplate>
                                   <asp:LinkButton ID="lnkReceive" runat="server" Text="Receive" OnClick="lnkReceive_Click" OnClientClick="return confirm('Are you Sure?')"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                           
    </asp:GridView>
        
        
        ------------aspx.cs page code------------------
    
     protected void gvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nbps = e.Row.Cells[8].Text;
                if(nbps== "&nbsp;")
                {
                    nbps = "";
                }
                else
                {
                    nbps = e.Row.Cells[8].Text;
                }
                if (nbps == "")
                {
                    LinkButton btn = (LinkButton)e.Row.FindControl("lnkissue");
                    LinkButton btn1 = (LinkButton)e.Row.FindControl("lnkReceive");
                    btn.Enabled = true;
                    btn1.Enabled = false;
                    btn1.ForeColor = System.Drawing.Color.Red;
                   
                }
                else
                {
                    LinkButton btn = (LinkButton)e.Row.FindControl("lnkissue");
                    LinkButton btn1 = (LinkButton)e.Row.FindControl("lnkReceive");
                    btn.Enabled = false;
                    btn.ForeColor = System.Drawing.Color.Red;
                    btn1.Enabled = true;
                }
               
            }
        }
