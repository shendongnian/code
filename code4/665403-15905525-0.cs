    <asp:LinkButton ID="Xtown" runat="server" OnClick="lnkButtonClick">Xtown</asp:LinkButton>
    private void UpdateDB(string id)
    {
         string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    
         using (SqlConnection conn = new SqlConnection(cs))
         {
            //*snip*
            cmd.Parameters.AddWithValue("@cityName", id);//ID from clicked control 
         }
    }
    protected void lnkButtonClick(object sender, EventArgs e)
    {
         string id = ((LinkButton)sender).ClientID;
         UpdateDB(id);
    }
