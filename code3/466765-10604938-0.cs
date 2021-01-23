     protected void ContentPlaceHolder1_Load(object sender, EventArgs e)
            {
                if (Session["selectedCustomer"] != null)
                {
                    ddlSelectedCustomer.SelectedValue = Session["selectedCustomer"].ToString();
                }
            }
----------
     <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server" OnLoad="ContentPlaceHolder1_Load">
     </asp:ContentPlaceHolder>
