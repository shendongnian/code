        <asp:GridView ID="gvSHowMostViewedArticles"  runat="server" AllowPaging="True" 
             AutoGenerateColumns="False"  Width="920px" BackColor="White" 
             BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
             Font-Names="Verdana" Font-Size="X-Small" ForeColor="Black" 
             GridLines="Horizontal" PageSize="10"   onrowdatabound="gvSHowMostViewedArticles_RowDataBound" 
    onrowcommand="gvSHowMostViewedArticles_RowCommand" onpageindexchanging="gvSHowMostViewedArticles_PageIndexChanging">
            
             <Columns>
              <asp:TemplateField HeaderText="Sno">
                    <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                   </ItemTemplate>
              </asp:TemplateField>
                                                <asp:BoundField DataField="ArticleTitle" HeaderText="Article Title" />
                                                <asp:BoundField DataField="FullName" HeaderText="Name" />
                                                <asp:BoundField DataField="Country" HeaderText="Country" />
            
    <asp:TemplateField HeaderText="Message">
           <ItemTemplate>
               <asp:LinkButton ID="lnkBtnShowMessage" runat="server" Text="Read" CommandName="showMessage" CommandArgument='<%# Eval("comID") %>' />
                                                    </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Activate">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkBtnActivateComment" runat="server" Text="Activate" CommandName="ActivateComment" CommandArgument='<%# Eval("comID") %>' />
                                                    </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="De Activate">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkBtnDeActivateComment" runat="server" Text="De-Activate" CommandName="DeActivateComment" CommandArgument='<%# Eval("comID") %>' />
                                                    </ItemTemplate>
                                             </asp:TemplateField>
            
            
                                            </Columns>
            
                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                
        
        
            protected void gvSHowMostViewedArticles_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                //Show Message
                LinkButton lb = e.Row.FindControl("lnkBtnShowMessage") as LinkButton;
                if (lb != null)
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
        
        
                //Activate
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbActivate = e.Row.FindControl("lnkBtnActivateComment") as LinkButton;
                    if (lbActivate != null)
                        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lbActivate);
        
                    lbActivate.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to Activate this comment " +
                    DataBinder.Eval(e.Row.DataItem, "ID") + "')");
                }
                //De Activate
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbActivate = e.Row.FindControl("lnkBtnDeActivateComment") as LinkButton;
                    if (lbActivate != null)
                        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lbActivate);
        
                    lbActivate.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to De-Activate this comment " +
                    DataBinder.Eval(e.Row.DataItem, "ID") + "')");
                }
            }
        
        
          protected void gvSHowMostViewedArticles_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                //Show Message
                if (e.CommandName == "showMessage")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    string strSql = "SELECT * FROM Comments WHERE comID = " + sno;
                    DataSet ds = DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = ds.Tables[0].Rows[0]["comMessage"].ToString();
                }
        
                // Activate Comment
                if (e.CommandName == "ActivateComment")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    String strSql = "UPDATE Comments SET Visible = 1 WHERE ID = " + sno;
                    DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = "Activated";
                }
        
                // De Activate Comment
                if (e.CommandName == "DeActivateComment")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    String strSql = "UPDATE Comments SET Visible = 0 WHERE ID = " + sno;
                    DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = "Deactivate";
        
                }
            }
