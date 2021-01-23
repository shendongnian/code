    protected void btn_Click(object sender, EventArgs e)
    {
         if (btn.Enabled)
         {
               // do something         
         }
    }
    <asp:Button ID="btn" runat="server" Enabled="false" OnClick="btn_Click" Text="Test" />
