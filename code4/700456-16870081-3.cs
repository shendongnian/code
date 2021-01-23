    // Your button
    <asp:Button runat="server" ID="btn" Text="Button" OnClick="clicked" />
        
    protected void clicked(object sender, EventArgs e)
    {
      // If you don't have update panel
      Page.ClientScript.RegisterStartupScript(
                      this.GetType(), 
                      "key001", 
                      "openModal('#dialog')", 
                      true);
       // If you have update panel
       ScriptManager.RegisterStartupScript(
                      this, 
                      this.GetType(), 
                      "key001", 
                      "openModal('#dialog')", 
                      true);
    }
