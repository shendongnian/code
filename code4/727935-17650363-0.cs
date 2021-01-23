        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" AllowSorting="True" 
                                                onpageindexchanging="gv_PageIndexChanging" 
                                                onsorting="gv_Sorting" GridLines="None" DataKeyNames="ID" 
                                                   PageSize="20" onrowdeleting="gv_RowDeleting" 
                                                   onrowdatabound="gv_RowDataBound" >
                            <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NumericFirstLast" NextPageText="Next" PageButtonCount="5" 
                        PreviousPageText="Previous" />
                           
                            <Columns>
                                <asp:BoundField DataField="SECURITIES_NAME" HeaderText="Securities Name" 
                                    SortExpression="SECURITIES" />
                                
                                <asp:BoundField DataField="FIN_YEAR" HeaderText="Financial Year" 
                                    SortExpression="FIN_YEAR" />
                                <asp:BoundField DataField="RECORD_DATE" HeaderText="Record Date" 
                                    SortExpression="RECORD_DATE" />
                                <asp:BoundField DataField="AGM_DATE" HeaderText="AGM Date" 
                                    SortExpression="AGM_DATE" />
                                <asp:BoundField DataField="CA_SEQ_NO" HeaderText="CA SEQ NO" 
                                    SortExpression="CA_SEQ_NO" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="actions">
                                            <asp:LinkButton ID="lbView" runat="server" CausesValidation="True" CommandName="Select" Text="View"></asp:LinkButton>
                                            <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="True" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="lbDelete" runat="server" OnClientClick="return confirm('Are you sure want to delete the Corporate Action?')" CausesValidation="False" 
                                                CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>            
                            </Columns>
                            <PagerStyle CssClass="pagination-flickr" BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <AlternatingRowStyle CssClass="altrow" />
                        </asp:GridView> 
    the codebehind cs:
    protected void Page_Load(object sender, EventArgs e)
        {
            IsAuthenticated.CheckSession();
            if (!IsPostBack)
            {
                if (Session["setFlash"] != null)
                {
                    if (Session["setFlash"].ToString() == "1")
                    {
                        ltrMsg.Text = @"<div class='message-green'>Save Successfully</div>";
                        Session["setFlash"] = null;
                    }
                    else
                    {
                        ltrMsg.Text = @"<div class='message'>Not Save Successfully</div>";
                        Session["setFlash"] = null;
                    }
                }
    
                common.gv(@"Select SECURITIES_ID,BO_FNC_GET_SECURITIES_NAME(SECURITIES_ID) SECURITIES_NAME,
                    CA_SEQ_NO,FIN_YEAR,RECORD_DATE,AGM_DATE,SETUP_DATE,ID,ROWID From CA_MST", gv);
                ViewState["sortingOrder"] = string.Empty;
                DataBindGrid("", "");  
              
            }
        }
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string wh = "ID='" + gv.DataKeys[e.RowIndex].Values[0].ToString() + "'";
            DataProcess.Save("CA_MST", wh);
    
            common.gv(@"Select SECURITIES_ID,BO_FNC_GET_SECURITIES_NAME(SECURITIES_ID) SECURITIES_NAME,
                    CA_SEQ_NO,FIN_YEAR,RECORD_DATE,AGM_DATE,SETUP_DATE,ID,ROWID FROM CA_MST", gv);
        }
       
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            common.gv(@"Select SECURITIES_ID,BO_FNC_GET_SECURITIES_NAME(SECURITIES_ID) SECURITIES_NAME,
                    CA_SEQ_NO,FIN_YEAR,RECORD_DATE,AGM_DATE,SETUP_DATE,ID,ROWID FROM CA_MST", gv);
            
        }
        private void DataBindGrid(string sortExpr, string sortOrder)
        {
            // GetDataTable returns a filled table
            DataTable dt = DataProcess.getDataTable(@"Select SECURITIES_ID,BO_FNC_GET_SECURITIES_NAME(SECURITIES_ID) SECURITIES_NAME,
                    CA_SEQ_NO,FIN_YEAR,RECORD_DATE,AGM_DATE,SETUP_DATE,ID,ROWID FROM CA_MST");
            // any check to validate dt
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
    
                if (sortExpr != string.Empty)
                    dv.Sort = sortExpr + " " + sortOrder;
    
                this.gv.DataSource = dv;
                this.gv.DataBind();
            }
            else
            {
                this.gv.DataSource = null;
                this.gv.DataBind();
            }
        }
        protected void gv_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataBindGrid(e.SortExpression, sortingOrder);
        }
        public string sortingOrder
        {
            get
            {
                if (ViewState["sortingOrder"].ToString() == "desc")
                    ViewState["sortingOrder"] = "asc";
                else
                    ViewState["sortingOrder"] = "desc";
    
                return ViewState["sortingOrder"].ToString();
            }
            set
            {
                ViewState["sortingOrder"] = value;
            }
        }
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbv = (LinkButton)e.Row.FindControl("lbView");
                lbv.PostBackUrl = "CaMstVw.aspx?rid=" + gv.DataKeys[e.Row.RowIndex].Values[0].ToString();
    
                LinkButton lb = (LinkButton)e.Row.FindControl("lbEdit");
                lb.PostBackUrl = "CaMstIns.aspx?rid=" + gv.DataKeys[e.Row.RowIndex].Values[0].ToString() ;
            }
        }
