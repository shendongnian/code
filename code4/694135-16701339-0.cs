    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["VolunteerSessionList"] != null)
       {
          RegisterUser.UserName = "test";
       }
    }
    
    <asp:CreateUserWizard ID="RegisterUser" runat="server" ...>
        <LayoutTemplate>
            ....
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                     ....
                     <asp:TextBox ID="UserName" runat="server" />
                     ....
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
