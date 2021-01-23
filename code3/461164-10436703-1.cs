    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlOne" runat="server" OnSelectedIndexChanged="ddlOne_OnSelectedIndexChanged" AutoPostBack="true" />
        <br />
        <br />
        <asp:DropDownList ID="ddlTwo" runat="server" />
        <br />
        <br />
        <asp:Button ID="btRemove" runat="server" Text="Remove" 
            onclick="btRemove_Click" />
    </div>
    </form>
----
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind data
                BindLists();
            }
        }
        /// <summary>
        /// Removes whatever Selected Item from ddlTwo that is 
        /// currently selected in ddlOne.
        /// </summary>
        private void RemoveFromTwoWhatIsSelectedInOne()
        {
            ddlTwo.Items.Remove(ddlOne.SelectedItem);
        }
        /// <summary>
        /// Click handler for btRemove. Calls the method 
        /// RemoveFromTwoWhatIsSelectedInOne()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btRemove_Click(object sender, EventArgs e)
        {
            RemoveFromTwoWhatIsSelectedInOne();
        }
        /// <summary>
        /// OnSelectedIndexChanged handler for ddlOne. Calls the method 
        /// RemoveFromTwoWhatIsSelectedInOne()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOne_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveFromTwoWhatIsSelectedInOne();
        }
        /// <summary>
        /// Binds a list of names the two Drop Down Lists, ddlOne and ddlTwo, by using 
        /// the same Data Source from the Manager.
        /// </summary>
        private void BindLists()
        {
            // Get the data
            Manager theManager = new Manager();
            List<Names> theNames = theManager.GetNames();
            // Assign the data source
            ddlOne.DataSource = theNames;
            ddlTwo.DataSource = theNames;
            // Bind each drop down list
            ddlOne.DataBind();
            ddlTwo.DataBind();
        }
