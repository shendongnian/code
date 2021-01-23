    <asp:Wizard runat="server" ID="mainWizard">
     <WizardSteps>
      <asp:WizardStep>
       <asp:Label runat="server" ID="lbl1" Text="Label one" />
      </asp:WizardStep>
      <asp:WizardStep>
       <asp:Label runat="server" ID="lbl2" Text="Label two" />
      </asp:WizardStep>
     </WizardSteps>
    </asp:Wizard>
    <asp:Button runat="server" ID="btnGetall" Text="Get All controls" 
                OnClick="btn_Click" />
    <br />
    <asp:Label runat="server" ID="lblResult" />
--------------
    protected void btn_Click(object sender, EventArgs e)
    {
       foreach (WizardStep step in mainWizard.WizardSteps)
       {
         foreach (Control cntrl in step.Controls)
         {
            if (cntrl is Label)
              lblResult.Text += ((Label)cntrl).Text + ",";
         }
        }
    }
